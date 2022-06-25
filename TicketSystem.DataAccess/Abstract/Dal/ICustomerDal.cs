using TicketSystem.Core.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Abstract.Dal
{
    public interface ICustomerDal : IRepositoryDal<Customer>
    {
        Task<Customer> GetUserByEMailAsync(string mail);
    }
}
