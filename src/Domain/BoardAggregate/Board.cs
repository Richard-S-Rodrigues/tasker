using Tasking.Domain.BoardAggregate.ValueObjects;
using Tasking.Domain.MemberAggregate.ValueObjects;
using Tasking.Domain.Shared;
using Tasking.Domain.TaskAggregate.ValueObjects;

namespace Tasking.Domain.BoardAggregate;

public sealed class Board : AggregateRoot<BoardId>
{
  public Board(
    BoardId id, 
    string name,
    List<TaskId> taskIds,
    List<MemberId> memberIds) : base(id)
  {
    BoardId = id;
    Name = name;
    TaskIds = taskIds;
    MemberIds = memberIds;
  }

  public BoardId BoardId { get; private set; }
  public string Name { get; private set; }
  public List<TaskId> TaskIds { get; private set; }
  public List<MemberId> MemberIds { get; private set; }
} 