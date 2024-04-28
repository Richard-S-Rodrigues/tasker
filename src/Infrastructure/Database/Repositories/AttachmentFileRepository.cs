using Tasker.Domain.AttachmentFileAgggregate;
using Tasker.Domain.AttachmentFileAggregate.Repositories;
using Tasker.Infrastructure.Context;

namespace Tasker.Infrastructure.Database.Repositories;

public class AttachmentFileRepository : IAttachmentFileRepository
{
  private readonly ApplicationDbContext _applicationDbContext;

  public AttachmentFileRepository(ApplicationDbContext applicationDbContext)
  {
    _applicationDbContext = applicationDbContext;
  }

  public async Task Add(AttachmentFile entity)
  {
    _applicationDbContext.Add(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task Delete(AttachmentFile entity)
  {
    _applicationDbContext.Remove(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task<AttachmentFile> Update(AttachmentFile entity)
  {
    _applicationDbContext.Update(entity);
    await _applicationDbContext.SaveChangesAsync();
    return entity;
  }
}