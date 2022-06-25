using TicketSystem.Core.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Abstract.Dal
{
    public interface IEmployeeDal : IRepositoryDal<Employee>
    {
        public Task<Employee> GetUserByEMailAsync(string mail);
    }
}
