using Tasker.Domain.CommentAggregate;
using Tasker.Domain.CommentAggregate.Repositories;
using Tasker.Domain.CommentAggregate.ValueObjects;
using Tasker.Infrastructure.Context;

namespace Tasker.Infrastructure.Database.Repositories;

public class CommentRepository : ICommentRepository
{
  private readonly ApplicationDbContext _applicationDbContext;

  public CommentRepository(ApplicationDbContext applicationDbContext)
  {
    _applicationDbContext = applicationDbContext;
  }

  public async Task Add(Comment entity)
  {
    _applicationDbContext.Comments.Add(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task Delete(CommentId id)
  {
    var comment = await _applicationDbContext.Comments.FindAsync(id);
    
    if (comment is not null)
    {
      _applicationDbContext.Comments.Remove(comment);
    }
    
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task<Comment> Update(Comment entity)
  {
    _applicationDbContext.Comments.Update(entity);
    await _applicationDbContext.SaveChangesAsync();
    return entity;
  }
}