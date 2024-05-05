namespace Tasker.Domain.Shared.Repository;

public interface IRepository<TEntity, TId>
{
  Task Add(TEntity entity);
  Task<TEntity> Update(TEntity entity);
  Task Delete(TId id);
}