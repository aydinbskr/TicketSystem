using TicketSystem.Core.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Abstract.Dal
{
    public interface ITicketDal : IRepositoryDal<Ticket>
    {
        Task<List<Ticket>> GetAllTicketsOfUser(int id);
    }
}
