using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.Repositories;
using Tasker.Domain.TaskAggregate.ValueObjects;
using Tasker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Tasker.Domain.TaskAggregate;

namespace Tasker.Infrastructure.Database.Repositories;

public class TaskRepository : ITaskRepository
{
  private readonly ApplicationDbContext _applicationDbContext;

  public TaskRepository(ApplicationDbContext applicationDbContext)
  {
    _applicationDbContext = applicationDbContext;
  }

  public async System.Threading.Tasks.Task Add(Domain.TaskAggregate.Task entity)
  {
    _applicationDbContext.Tasks.Add(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async System.Threading.Tasks.Task Delete(TaskId id)
  {
    var task = await _applicationDbContext.Tasks.FindAsync(id);

    if (task is not null)
    {
      _applicationDbContext.Tasks.Remove(task);
    }
    
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task<Domain.TaskAggregate.Task> Update(Domain.TaskAggregate.Task entity)
  {
    _applicationDbContext.Tasks.Update(entity);
    await _applicationDbContext.SaveChangesAsync();
    return entity;
  }

  public async Task<Domain.TaskAggregate.Task?> Get(TaskId id)
  {
    return await _applicationDbContext.Tasks.FindAsync(id);
  }

  public async Task<List<Domain.TaskAggregate.Task>> GetAllByBoardId(BoardId boardId)
  {
    return await _applicationDbContext.Tasks.Where(t => t.BoardId == boardId && t.DeletedAt == null).ToListAsync();
  }

  public async System.Threading.Tasks.Task AddChecklist(Domain.TaskAggregate.TaskChecklist taskChecklist)
  {
    var task = _applicationDbContext.Tasks.Find(taskChecklist.TaskId);
    if (task is not null)
    {
      task.TaskChecklists.Add(taskChecklist);
    }
    await _applicationDbContext.SaveChangesAsync();
  }

  public async System.Threading.Tasks.Task UpdateChecklist(Domain.TaskAggregate.TaskChecklist taskChecklist)
  {
    var task = _applicationDbContext.Tasks.Find(taskChecklist.TaskId);
    if (task is not null)
    {
      var checklist = task.TaskChecklists.FirstOrDefault(tc => tc.Id.Value == taskChecklist.Id.Value);
      if (checklist is not null)
      {
        checklist.Update(taskChecklist.Title, taskChecklist.Description, taskChecklist.IsDone);
      }
    }
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task<Domain.TaskAggregate.TaskChecklist> GetTaskChecklistById(TaskId taskId, TaskChecklistId taskChecklistId)
  {
    var task = await _applicationDbContext.Tasks.FindAsync(taskId);
    if (task is null) return null;
    
    return task.TaskChecklists.FirstOrDefault(tc => tc.Id == taskChecklistId);
  }

  public async System.Threading.Tasks.Task AddAttachmentFile(AttachmentFile attachmentFile)
  {
    var task = await _applicationDbContext.Tasks.FindAsync(attachmentFile.TaskId);
    if (task is not null)
    {
      task.AttachmentFiles.Add(attachmentFile);
    }
    await _applicationDbContext.SaveChangesAsync();
  }
  public async System.Threading.Tasks.Task DeleteAttachmentFile(AttachmentFile attachmentFile)
  {
    var task = await _applicationDbContext.Tasks.FindAsync(attachmentFile.TaskId);
    if (task is not null)
    {
      task.AttachmentFiles.Remove(attachmentFile);
    }
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task<List<AttachmentFile>> GetAttachmentFilesByTaskId(TaskId taskId)
  {
    var task = await _applicationDbContext.Tasks.FindAsync(taskId);
    if (task is null) return null;

    return task.AttachmentFiles.ToList();
  }

  public async Task<AttachmentFile?> GetAttachmentFile(TaskId taskId, AttachmentFileId attachmentFileId)
  {
    var task = await _applicationDbContext.Tasks.FindAsync(taskId);
    if (task is null) return null;

    return task.AttachmentFiles.FirstOrDefault(af => af.Id == attachmentFileId);
  }
}