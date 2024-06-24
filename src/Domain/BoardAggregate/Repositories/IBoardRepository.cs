using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.Shared.Repository;

namespace Tasker.Domain.BoardAggregate.Repositories;

public interface IBoardRepository : IRepository<Board, BoardId>
{
  Task<List<Board>> GetAll();
  Task<Board> AddMemberToBoard(BoardId boardId, Member member);
  Task<List<Member>> GetAllMembersByBoardId(BoardId boardId);
}