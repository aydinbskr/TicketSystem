using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Abstract.Dal;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Dals
{
    public class EfSceneDal : EntityRepositoryBase<Scene, AppContext>, ISceneDal
    {
        public async Task<Scene> GetSceneWithSeatsAndSessions(int id)
        {
            using (AppContext context = new AppContext())
            {
                return await context.Set<Scene>().Include(s => s.Seats).Include(s => s.Sessions).AsNoTracking().SingleOrDefaultAsync(s => s.SceneId == id);
            }
        }
    }
}
