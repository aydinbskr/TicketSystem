using TicketSystem.Core.Utilities.Results;
using TicketSystem.Entities.Dtos.SessionDtos;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Abstract
{
    public interface ISessionService : IGenericService<Session>
    {
        Task<IDataResult<List<Session>>> GetAllSessionsOfMovieAsync(int id);
        Task<IResult> CheckSeat(int sessionId, int seatNumber);
        IDataResult<List<SessionDetailDto>> GetSessionDetailAsync(int id, DateTime date);
        IDataResult<List<SessionDetailDto>> GetListSessions();
        IDataResult<SessionDetailDto> GetSessionAsync(int id);
    }
}
