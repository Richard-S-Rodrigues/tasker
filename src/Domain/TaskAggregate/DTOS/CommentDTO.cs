namespace Tasker.Domain.TaskAggregate.Queries;

public record CommentDTO(
  Guid? Id,
  string Text, 
  Guid MemberId,
  string MemberName,
  Guid TaskId,
  DateTime Date);