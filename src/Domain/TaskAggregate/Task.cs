using Tasker.Domain.AttachmentFileAgggregate.ValueObjects;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.CommentAggregate.ValueObjects;
using Tasker.Domain.Shared;
using Tasker.Domain.TaskAggregate.Enums;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate;

public sealed class Task : AggregateRoot<TaskId>
{
  public Task(
    TaskId id,
    TaskParentId parentId,
    BoardId boardId,
    string title,
    string description,
    TimeDetails timeDetails,
    Status status,
    Priority priority,
    TaskId[] subTaskIds,
    List<Responsible> responsibles,
    List<AttachmentFileId> attachmentFileIds,
    List<CommentId> commentIds
  ) : base(id)
  {
    ParentId = parentId;
    BoardId = boardId;
    Title = title;
    Description = description;
    TimeDetails = timeDetails;
    Status = status;
    Priority = priority;
    SubTaskIds = subTaskIds;
    Responsibles = responsibles;
    AttachmentFileIds = attachmentFileIds;
    CommentIds = commentIds;
  }
  public TaskParentId ParentId { get; private set; }
  public BoardId BoardId { get; private set; }
  public string Title { get; private set; }
  public string Description { get; private set; }
  public TimeDetails TimeDetails { get; private set; }
  public Status Status { get; private set; }
  public Priority Priority { get; private set; }
  public TaskId[] SubTaskIds { get; private set; }
  public List<Responsible> Responsibles { get; private set; }
  public List<AttachmentFileId> AttachmentFileIds { get; private set; }
  public List<CommentId> CommentIds { get; private set; }

  #pragma warning disable
  public Task() {}
  #pragma warning restore
} 