using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.Shared.Repository;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Repositories;

public interface ITaskRepository : IRepository<Task, TaskId>
{
  System.Threading.Tasks.Task<List<Task>> GetAllByBoardId(BoardId boardId);
  System.Threading.Tasks.Task AddChecklist(TaskChecklist taskChecklist);
  System.Threading.Tasks.Task UpdateChecklist(TaskChecklist taskChecklist);
  System.Threading.Tasks.Task<TaskChecklist> GetTaskChecklistById(TaskId taskId, TaskChecklistId taskChecklistId);
  System.Threading.Tasks.Task AddAttachmentFile(AttachmentFile attachmentFile);
  System.Threading.Tasks.Task DeleteAttachmentFile(AttachmentFile attachmentFile);
  System.Threading.Tasks.Task<List<AttachmentFile>> GetAttachmentFilesByTaskId(TaskId taskId);
  System.Threading.Tasks.Task<AttachmentFile?> GetAttachmentFile(TaskId taskId, AttachmentFileId attachmentFileId);
  System.Threading.Tasks.Task AddComment(Comment comment);
  System.Threading.Tasks.Task DeleteComment(Comment comment);
  System.Threading.Tasks.Task<Comment?> GetComment(TaskId taskId, CommentId commentId);
}