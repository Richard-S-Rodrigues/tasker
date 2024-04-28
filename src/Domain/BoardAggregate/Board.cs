using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.Shared;

namespace Tasker.Domain.BoardAggregate;

public sealed class Board : AggregateRoot<BoardId>
{
  public Board(
    BoardId id, 
    string name) : base(id)
  {
    Name = name;
  }

  public string Name { get; private set; }

  #pragma warning disable
  public Board() {}
  #pragma warning restore
} 