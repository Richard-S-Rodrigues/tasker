
using Tasker.Domain.BoardAggregate.Queries;

namespace Tasker.Application.Boards.Queries;

public interface IBoardQueries
{
  Task<List<BoardDTO>> GetAllBoards();
}