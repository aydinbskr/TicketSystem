using TicketSystem.Core.Utilities.Results;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Abstract
{
    public interface ICustomerService : IGenericService<Customer>
    {
        public Task<IDataResult<Customer>> GetUserByEMailAsync(string mail);
    }
}
