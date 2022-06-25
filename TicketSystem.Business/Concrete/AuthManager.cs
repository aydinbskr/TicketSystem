using AutoMapper;
using System.Security.Claims;
using TicketSystem.Business.Abstract;
using TicketSystem.Business.Utilities.Extentions;
using TicketSystem.Core.Utilities.Results;
using TicketSystem.Entities.Dtos;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        readonly IEmployeeService _employeeService;
        readonly ICustomerService _customerService;
        readonly IMapper _mapper;

        public AuthManager(IMapper mapper, ICustomerService customerService, IEmployeeService employeeService)
        {
            _mapper = mapper;
            _customerService = customerService;
            _employeeService = employeeService;
        }

        public async Task<IDataResult<List<Claim>>> CreateCustomer(CustomerCreateDto customerCreateDto)
        {
            if (customerCreateDto != null)
            {
                var customer = _mapper.Map<Customer>(customerCreateDto);
                var result = await _customerService.CreateAsync(customer);
                if (result.Success)
                {
                    return await Signin(new LoginDto() { Email = result.Data.Email, Password = result.Data.Password, LoginType = "Customer" });
                }
            }
            return new ErrorDataResult<List<Claim>>();
        }

        public async Task<IDataResult<List<Claim>>> CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            if (employeeCreateDto != null)
            {
                var employee = _mapper.Map<Employee>(employeeCreateDto);
                var result = await _employeeService.CreateAsync(employee);
                if (result.Success)
                {
                    await Signin(new LoginDto() { Email = result.Data.EmpEmail, Password = result.Data.EmpPassword, LoginType = "Employee" });
                }
            }
            return new ErrorDataResult<List<Claim>>();
        }

        public async Task<IDataResult<List<Claim>>> Signin(LoginDto loginDto)
        {
            if (loginDto != null)
            {

                switch (loginDto.LoginType)
                {
                    case "Customer":
                        var customerResult = await _customerService.GetUserByEMailAsync(loginDto.Email!);
                        if (customerResult.Data != null && loginDto.Password == customerResult.Data.Password)
                        {
                            var claims = new List<Claim>();
                            claims.AddEmail(customerResult.Data.Email!);
                            claims.AddName(customerResult.Data.Name!);
                            claims.Add(new Claim("Id", customerResult.Data.CustomerId.ToString()));
                            claims.AddNameIdentifier(customerResult.Data.Name + customerResult.Data.Surname);
                            claims.AddRoles(new string[] { "Customer" });
                            return new SuccessDataResult<List<Claim>>(claims);
                        }

                        break;

                    case "Employee":
                        var employeeResult = await _employeeService.GetUserByEMailAsync(loginDto.Email!);
                        if (employeeResult.Data != null && loginDto.Password == employeeResult.Data.EmpPassword)
                        {
                            var claims = new List<Claim>();
                            claims.AddEmail(employeeResult.Data.EmpEmail!);
                            claims.AddName(employeeResult.Data.EmpName!);
                            claims.Add(new Claim("Id", employeeResult.Data.EmpoyeeId.ToString()));
                            claims.AddNameIdentifier(employeeResult.Data.EmpName + employeeResult.Data.EmpSurname);
                            claims.AddRoles(new string[] { "Employee" });
                            return new SuccessDataResult<List<Claim>>(claims);
                        }
                        break;
                    default:
                        break;
                }
            }
            return new ErrorDataResult<List<Claim>>();
        }
    }
}
