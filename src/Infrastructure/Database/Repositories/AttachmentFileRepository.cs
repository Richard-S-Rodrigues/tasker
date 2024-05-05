using Tasker.Domain.AttachmentFileAggregate;
using Tasker.Domain.AttachmentFileAggregate.Repositories;
using Tasker.Domain.AttachmentFileAggregate.ValueObjects;
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
    _applicationDbContext.AttachmentFiles.Add(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task Delete(AttachmentFileId id)
  {
    var attachmentFile = await _applicationDbContext.AttachmentFiles.FindAsync(id); 
    if (attachmentFile is not null)
    {
      _applicationDbContext.AttachmentFiles.Remove(attachmentFile);
    }
    
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task<AttachmentFile> Update(AttachmentFile entity)
  {
    _applicationDbContext.AttachmentFiles.Update(entity);
    await _applicationDbContext.SaveChangesAsync();
    return entity;
  }
}