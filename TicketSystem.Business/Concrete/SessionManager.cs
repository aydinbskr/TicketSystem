using TicketSystem.Business.Abstract;
using TicketSystem.Business.Utilities.ValidationRules;
using TicketSystem.Core.Aspects.Autofac;
using TicketSystem.Core.Utilities.Results;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.Dtos.SessionDtos;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Concrete
{
    public class SessionManager : ISessionService
    {
        readonly ISessionDal _seesionDal;
        readonly ISceneService _sceneService;

        public SessionManager(ISessionDal seesionDal, ISceneService sceneService)
        {
            _seesionDal = seesionDal;
            _sceneService = sceneService;
        }

        public async Task<IResult> CheckSeat(int sessionId, int seatNumber)
        {
            var session = await _seesionDal.GetByFilterAsync(s => s.SessionId == sessionId);
            if (session != null)
            {
                var scene = await _sceneService.GetSceneWithDetailAsync(session.SceneId);
                if (scene != null && scene.Data.Seats != null)
                {
                    var result = scene.Data.Seats.Any(s => s.SessionId == session.SessionId && s.SeatNumber == seatNumber);
                    if (result)
                        return new ErrorResult();
                }
            }
            return new SuccessResult();
        }

        [ValidationAspect(typeof(SessionValidationRules))]
        public async Task<IDataResult<Session>> CreateAsync(Session session)
        {
            var addedSession = await _seesionDal.CreateAsync(session);
            if (addedSession != null)
            {
                return new SuccessDataResult<Session>(addedSession);
            }
            return new ErrorDataResult<Session>();
        }

        public async Task<IDataResult<List<Session>>> GetAllAsync()
        {
            var list = await _seesionDal.GetAllAsync();
            if (list != null)
            {
                return new SuccessDataResult<List<Session>>(list);
            }
            return new ErrorDataResult<List<Session>>();
        }

        public async Task<IDataResult<List<Session>>> GetAllSessionsOfMovieAsync(int id)
        {
            var result = await _seesionDal.GetAllAsync(s => s.MovieId == id);
            if (result != null)
            {
                return new SuccessDataResult<List<Session>>(result);
            }
            return new ErrorDataResult<List<Session>>();
        }

        public async Task<IDataResult<Session>> GetByIdAsync(int id)
        {
            var session = await _seesionDal.GetByFilterAsync(s => s.SessionId == id);
            if (session != null)
            {
                return new SuccessDataResult<Session>(session);
            }
            return new ErrorDataResult<Session>();
        }

        public IDataResult<List<SessionDetailDto>> GetListSessions()
        {
            var session = _seesionDal.GetListSessions();
            if (session != null)
            {
                return new SuccessDataResult<List<SessionDetailDto>>(session);
            }
            return new ErrorDataResult<List<SessionDetailDto>>();
        }

        public IDataResult<SessionDetailDto> GetSessionAsync(int id)
        {
            var session = _seesionDal.GetSession(id);
            if (session != null)
            {
                return new SuccessDataResult<SessionDetailDto>(session);
            }
            return new ErrorDataResult<SessionDetailDto>();
        }

        public IDataResult<List<SessionDetailDto>> GetSessionDetailAsync(int id, DateTime date)
        {
            var session = _seesionDal.GetSessionDetail(id,date);
            if (session != null)
            {
                return new SuccessDataResult<List<SessionDetailDto>>(session);
            }
            return new ErrorDataResult<List<SessionDetailDto>>();
        }

        public async Task<IResult> RemoveAsync(Session session)
        {
            _seesionDal.Remove(session);
            return await Task.FromResult(new SuccessResult());
        }

        [ValidationAspect(typeof(SessionValidationRules))]
        public async Task<IDataResult<Session>> UpdateAsync(Session session)
        {
            var updatedSession = _seesionDal.Update(session);
            return await Task.FromResult(new SuccessDataResult<Session>(updatedSession));
        }
    }
}
