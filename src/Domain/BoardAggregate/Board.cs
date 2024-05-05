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

  public static Board Create(string name)
  {
    return new Board(new BoardId(Guid.NewGuid()), name);
  }

  #pragma warning disable
  public Board() {}
  #pragma warning restore
} 