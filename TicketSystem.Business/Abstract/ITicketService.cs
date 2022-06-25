using TicketSystem.Core.Utilities.Results;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Abstract
{
    public interface ITicketService : IGenericService<Ticket>
    {
        Task<IDataResult<List<Ticket>>> GetAllTicketOfUser(int id);
    }
}
