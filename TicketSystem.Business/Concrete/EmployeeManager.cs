using TicketSystem.Business.Abstract;
using TicketSystem.Business.Utilities.ValidationRules;
using TicketSystem.Core.Aspects.Autofac;
using TicketSystem.Core.Utilities.Results;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        readonly IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        [ValidationAspect(typeof(EmployeeValidationRules))]
        public async Task<IDataResult<Employee>> CreateAsync(Employee employee)
        {
            var addedEmployee = await _employeeDal.CreateAsync(employee);
            if (addedEmployee != null)
            {
                return new SuccessDataResult<Employee>(employee);
            }
            return new ErrorDataResult<Employee>();
        }

        public async Task<IDataResult<List<Employee>>> GetAllAsync()
        {
            var list = await _employeeDal.GetAllAsync();
            if (list != null)
            {
                return new SuccessDataResult<List<Employee>>(list);
            }
            return new ErrorDataResult<List<Employee>>();
        }

        public async Task<IDataResult<Employee>> GetByIdAsync(int id)
        {
            var employee = await _employeeDal.GetByFilterAsync(e => e.EmpoyeeId == id);
            if (employee != null)
            {
                return new SuccessDataResult<Employee>(employee);
            }
            return new ErrorDataResult<Employee>();
        }

        public async Task<IDataResult<Employee>> GetUserByEMailAsync(string mail)
        {
            var result = await _employeeDal.GetUserByEMailAsync(mail);
            if (result != null)
            {
                return new SuccessDataResult<Employee>(result);
            }
            return new ErrorDataResult<Employee>();
        }

        public async Task<IResult> RemoveAsync(Employee employee)
        {
            _employeeDal.Remove(employee);
            return await Task.FromResult(new SuccessResult());
        }

        [ValidationAspect(typeof(EmployeeValidationRules))]
        public async Task<IDataResult<Employee>> UpdateAsync(Employee employee)
        {
            var updatedEmployee = _employeeDal.Update(employee);
            return await Task.FromResult(new SuccessDataResult<Employee>(updatedEmployee));
        }
    }
}
