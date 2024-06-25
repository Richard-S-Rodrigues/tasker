using FluentValidation;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.Shared;
using Tasker.Domain.TaskAggregate.Enums;
using Tasker.Domain.TaskAggregate.Validation;
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
    List<AttachmentFile> attachmentFiles,
    List<Comment> comments,
    List<TaskChecklist> taskChecklists
  ) : base(id)
  {
    BoardId = boardId;
    Title = title;
    Description = description;
    TimeDetails = timeDetails;
    Status = status;
    Priority = priority;
    AttachmentFiles = attachmentFiles;
    Comments = comments;
    TaskChecklists = taskChecklists;

    var validator = new TaskValidator();
    validator.ValidateAndThrow(this);
  }
  public BoardId BoardId { get; private set; }
  public string Title { get; private set; }
  public string? Description { get; private set; }
  public TimeDetails TimeDetails { get; private set; }
  public Status Status { get; private set; }
  public Priority Priority { get; private set; }
  public List<AttachmentFile> AttachmentFiles { get; private set; }
  public List<Comment> Comments { get; private set; }
  public List<TaskChecklist> TaskChecklists { get; private set; }

  public static Task Create(
    BoardId boardId,
    string title,
    string? description,
    TimeDetails timeDetails,
    Status status,
    Priority priority,
    List<AttachmentFile> attachmentFiles,
    List<Comment> comments,
    List<TaskChecklist> taskChecklists)
  {
    return new Task(
      new TaskId(Guid.NewGuid()), 
      boardId, 
      title, 
      description, 
      timeDetails, 
      status, 
      priority,  
      attachmentFiles, 
      comments,
      taskChecklists); 
  }

  #pragma warning disable
  public Task() {}
  #pragma warning restore
} 