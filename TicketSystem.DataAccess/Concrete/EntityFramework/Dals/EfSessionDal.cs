using TicketSystem.Core.Abstract.Dal;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.Dtos.SessionDtos;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.DataAccess.Concrete.EntityFramework.Dals
{
    public class EfSessionDal : EntityRepositoryBase<Session, AppContext>, ISessionDal
    {
        public List<SessionDetailDto> GetSessionDetail(int id,DateTime date)
        {
            using (AppContext context = new AppContext())
            {
                var result = from s in context.Sessions
                             join m in context.Movies
                             on s.MovieId equals m.MovieId
                             join sc in context.Scenes
                             on s.SceneId equals sc.SceneId
                             where m.MovieId == id && s.SessionTime.Date==date.Date
                             select new SessionDetailDto
                             {
                                 SessionId = s.SessionId,
                                 SessionTime = s.SessionTime,
                                 MovieName = m.MovieName,
                                 SceneId = s.SceneId,
                                 SceneType = sc.SceneType
                                 
                             };
                return result.ToList();
            }
        }
        public SessionDetailDto GetSession(int id)
        {
            using (AppContext context = new AppContext())
            {
                var result = from s in context.Sessions
                             join m in context.Movies
                             on s.MovieId equals m.MovieId
                             join sc in context.Scenes
                             on s.SceneId equals sc.SceneId
                             where s.SessionId == id
                             select new SessionDetailDto
                             {
                                 SessionId = s.SessionId,
                                 SessionTime = s.SessionTime,
                                 MovieName = m.MovieName,
                                 SceneId = s.SceneId,
                                 SceneType = sc.SceneType

                             };
                return result.SingleOrDefault();
            }
        }
            public List<SessionDetailDto> GetListSessions()
            {
                using (AppContext context = new AppContext())
                {
                    var result = from s in context.Sessions
                                 join m in context.Movies
                                 on s.MovieId equals m.MovieId
                                 join sc in context.Scenes
                                 on s.SceneId equals sc.SceneId
                                
                                 select new SessionDetailDto
                                 {
                                     SessionId = s.SessionId,
                                     SessionTime = s.SessionTime,
                                     MovieName = m.MovieName,
                                     SceneId = s.SceneId,
                                     SceneType = sc.SceneType

                                 };
                    return result.ToList();
                }
            }
        
    }
}
