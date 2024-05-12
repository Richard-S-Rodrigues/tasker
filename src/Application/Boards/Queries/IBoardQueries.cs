
using Tasker.Domain.BoardAggregate;

namespace Tasker.Application.Boards.Queries;

public interface IBoardQueries
{
  Task<List<Board>> GetAllBoards();
}