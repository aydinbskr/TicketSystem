using TicketSystem.Core.Utilities.Results;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Abstract
{
    public interface ISceneService : IGenericService<Scene>
    {
        Task<IDataResult<Scene>> GetSceneWithDetailAsync(int id);
    }
}
