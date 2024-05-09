using Tasker.Domain.BoardAggregate.ValueObjects;

namespace Tasker.Domain.BoardAggregate.Queries;

public record BoardDTO(BoardId Id, string Name)
{
  public static BoardDTO ToDTO(Board entity)
  {
    return new BoardDTO(entity.Id, entity.Name);
  }
};