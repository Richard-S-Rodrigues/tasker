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
    BoardId boardId,
    string title,
    string? description,
    TimeDetails timeDetails,
    Status status,
    Priority priority,
    List<Responsible> responsibles,
    List<AttachmentFile> attachmentFiles,
    List<CommentId> commentIds
  ) : base(id)
  {
    BoardId = boardId;
    Title = title;
    Description = description;
    TimeDetails = timeDetails;
    Status = status;
    Priority = priority;
    Responsibles = responsibles;
    AttachmentFiles = attachmentFiles;
    CommentIds = commentIds;
  }
  public BoardId BoardId { get; private set; }
  public string Title { get; private set; }
  public string? Description { get; private set; }
  public TimeDetails TimeDetails { get; private set; }
  public Status Status { get; private set; }
  public Priority Priority { get; private set; }
  public List<Responsible> Responsibles { get; private set; }
  public List<AttachmentFile> AttachmentFiles { get; private set; }
  public List<CommentId> CommentIds { get; private set; }

  public static Task Create(
    BoardId boardId,
    string title,
    string? description,
    TimeDetails timeDetails,
    Status status,
    Priority priority,
    List<Responsible> responsibles,
    List<AttachmentFile> attachmentFiles,
    List<CommentId> commentIds)
  {
    return new Task(
      new TaskId(Guid.NewGuid()), 
      boardId, 
      title, 
      description, 
      timeDetails, 
      status, 
      priority, 
      responsibles, 
      attachmentFiles, 
      commentIds); 
  }

  #pragma warning disable
  public Task() {}
  #pragma warning restore
} 