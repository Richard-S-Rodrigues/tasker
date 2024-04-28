namespace Tasker.Domain.Shared.Repository;

public interface IRepository<TEntity>
{
  Task Add(TEntity entity);
  Task<TEntity> Update(TEntity entity);
  Task Delete(TEntity entity);
}