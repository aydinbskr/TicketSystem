using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Abstract.Dal;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Dals
{
    public class EfEmployeeDal : EntityRepositoryBase<Employee, AppContext>, IEmployeeDal
    {
        public async Task<Employee> GetUserByEMailAsync(string mail)
        {
            using (AppContext context = new())
            {
                var result = await context.Set<Employee>().FirstOrDefaultAsync(c => c.EmpEmail == mail);
                return result;
            }
        }
    }
}
