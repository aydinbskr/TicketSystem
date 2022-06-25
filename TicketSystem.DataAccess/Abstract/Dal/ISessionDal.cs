using TicketSystem.Core.Abstract.Dal;
using TicketSystem.Entities.Dtos.SessionDtos;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Abstract.Dal
{
    public interface ISessionDal : IRepositoryDal<Session>
    {
        List<SessionDetailDto> GetSessionDetail(int id, DateTime date);
        SessionDetailDto GetSession(int id);
        List<SessionDetailDto> GetListSessions();
    }
}
