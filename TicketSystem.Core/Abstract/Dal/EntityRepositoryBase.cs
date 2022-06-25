using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketSystem.Core.Abstract.Entities;
using TicketSystem.Core.Concrete.Entities.Enums;

namespace TicketSystem.Core.Abstract.Dal
{
    public class EntityRepositoryBase<TEntity, TContext> : IRepositoryDal<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            using (TContext context = new())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public void Remove(TEntity entity)
        {
            using (TContext context = new())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            using (TContext context = new())
            {
                return await context.Set<TEntity>().AsNoTracking().ToListAsync();
            }
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new())
            {
                return await context.Set<TEntity>().AsNoTracking().Where(filter).ToListAsync();
            }
        }
        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> selector, OrderType orderByType = OrderType.DESC)
        {
            using (TContext context = new())
            {
                return orderByType == OrderType.ASC ? await context.Set<TEntity>().AsNoTracking().OrderBy(selector).ToListAsync() : await context.Set<TEntity>().AsNoTracking().OrderByDescending(selector).ToListAsync();
            }
        }
        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> selector, OrderType orderByType = OrderType.DESC)
        {
            using (TContext context = new())
            {
                return orderByType == OrderType.ASC ? await context.Set<TEntity>().AsNoTracking().Where(filter).OrderBy(selector).ToListAsync() : await context.Set<TEntity>().AsNoTracking().Where(filter).OrderByDescending(selector).ToListAsync();
            }
        }

        public async Task<TEntity?> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, bool asNoTracking = false)
        {
            using (TContext context = new())
            {
                return asNoTracking ? await context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(filter) : await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (TContext context = new())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}
