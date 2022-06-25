using TicketSystem.Core.Utilities.Results;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Abstract
{
    public interface IEmployeeService : IGenericService<Employee>
    {
        public Task<IDataResult<Employee>> GetUserByEMailAsync(string mail);
    }
}
