using TicketSystem.Core.Utilities.Results;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Abstract
{
    public interface ISeatService : IGenericService<Seat>
    {
        Task<IDataResult<List<Seat>>> GetBySceneIdAsync(int id);
    }
}
