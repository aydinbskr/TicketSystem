using TicketSystem.Core.Utilities.Results;

namespace TicketSystem.Business.Abstract
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<IDataResult<List<TEntity>>> GetAllAsync();
        Task<IDataResult<TEntity>> CreateAsync(TEntity entity);
        Task<IDataResult<TEntity>> UpdateAsync(TEntity entity);
        Task<IResult> RemoveAsync(TEntity entity);
        Task<IDataResult<TEntity>> GetByIdAsync(int id);
    }
}
