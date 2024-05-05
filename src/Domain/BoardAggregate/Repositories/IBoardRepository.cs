using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.Shared.Repository;

namespace Tasker.Domain.BoardAggregate.Repositories;

public interface IBoardRepository : IRepository<Board, BoardId>
{

}