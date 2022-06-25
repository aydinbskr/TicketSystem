using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Abstract.Dal;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Dals
{
    public class EfTicketDal : EntityRepositoryBase<Ticket, AppContext>, ITicketDal
    {
        public async Task<List<Ticket>> GetAllTicketsOfUser(int id)
        {
            using (AppContext context = new())
            {
                return await context.Set<Ticket>().Where(t => t.CustomerId == id).ToListAsync();
            }
        }
    }
}
