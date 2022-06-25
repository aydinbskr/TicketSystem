using TicketSystem.Core.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Abstract.Dal
{
    public interface ISceneDal : IRepositoryDal<Scene>
    {
        Task<Scene> GetSceneWithSeatsAndSessions(int id);
    }
}
