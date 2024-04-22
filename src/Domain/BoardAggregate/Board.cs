using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.MemberAggregate.ValueObjects;
using Tasker.Domain.Shared;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.BoardAggregate;

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