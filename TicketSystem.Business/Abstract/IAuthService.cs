using System.Security.Claims;
using TicketSystem.Core.Utilities.Results;
using TicketSystem.Entities.Dtos;

namespace TicketSystem.Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<List<Claim>>> CreateEmployee(EmployeeCreateDto userCreateDto);
        Task<IDataResult<List<Claim>>> CreateCustomer(CustomerCreateDto userCreateDto);
        Task<IDataResult<List<Claim>>> Signin(LoginDto loginDto);
    }
}
