using TicketSystem.Business.Abstract;
using TicketSystem.Business.Utilities.ValidationRules;
using TicketSystem.Core.Aspects.Autofac;
using TicketSystem.Core.Utilities.Results;
using TicketSystem.DataAccess.Abstract.Dal;
using TicketSystem.Entities.SystemEntities;

namespace TicketSystem.Business.Concrete
{
    public class SceneManager : ISceneService
    {
        readonly ISceneDal _sceneDal;

        public SceneManager(ISceneDal sceneDal)
        {
            _sceneDal = sceneDal;
        }

        [ValidationAspect(typeof(SceneValidationRules))]
        public async Task<IDataResult<Scene>> CreateAsync(Scene scene)
        {
            var addedScene = await _sceneDal.CreateAsync(scene);
            if (addedScene != null)
            {
                return new SuccessDataResult<Scene>(addedScene);
            }
            return new ErrorDataResult<Scene>();
        }

        public async Task<IDataResult<List<Scene>>> GetAllAsync()
        {
            var list = await _sceneDal.GetAllAsync();
            if (list != null)
            {
                return new SuccessDataResult<List<Scene>>(list);
            }
            return new ErrorDataResult<List<Scene>>();

        }

        public async Task<IDataResult<Scene>> GetByIdAsync(int id)
        {
            var scene = await _sceneDal.GetByFilterAsync(s => s.SceneId == id);
            if (scene != null)
            {
                return new SuccessDataResult<Scene>(scene);
            }
            return new ErrorDataResult<Scene>();
        }

        public async Task<IDataResult<Scene>> GetSceneWithDetailAsync(int id)
        {
            var result = await _sceneDal.GetSceneWithSeatsAndSessions(id);
            if (result != null)
            {
                return new SuccessDataResult<Scene>(result);
            }
            return new ErrorDataResult<Scene>();
        }

        public async Task<IResult> RemoveAsync(Scene scene)
        {
            _sceneDal.Remove(scene);
            return await Task.FromResult(new SuccessResult());
        }

        [ValidationAspect(typeof(SceneValidationRules))]
        public async Task<IDataResult<Scene>> UpdateAsync(Scene scene)
        {
            var updatedScene = _sceneDal.Update(scene);
            return await Task.FromResult(new SuccessDataResult<Scene>(updatedScene));
        }
    }
}
