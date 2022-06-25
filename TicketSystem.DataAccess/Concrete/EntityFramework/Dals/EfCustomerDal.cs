using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Abstract.Dal;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Dals
{
    public class EfCustomerDal : EntityRepositoryBase<Customer, AppContext>, ICustomerDal
    {
        public async Task<Customer> GetUserByEMailAsync(string mail)
        {
            using (AppContext context = new())
            {
                var result = await context.Set<Customer>().FirstOrDefaultAsync(c => c.Email == mail);
                return result;
            }
        }
    }
}
