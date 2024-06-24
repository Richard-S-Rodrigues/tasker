using Microsoft.EntityFrameworkCore;
using Tasker.Domain.BoardAggregate;
using Tasker.Domain.BoardAggregate.Repositories;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Infrastructure.Context;

namespace Tasker.Infrastructure.Database.Repositories;

public class BoardRepository : IBoardRepository
{
  private readonly ApplicationDbContext _applicationDbContext;

  public BoardRepository(ApplicationDbContext applicationDbContext)
  {
    _applicationDbContext = applicationDbContext;
  }

  public async Task Add(Board entity)
  {
    _applicationDbContext.Boards.Add(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task Delete(BoardId id)
  {
    var board = await _applicationDbContext.Boards.FindAsync(id);
    if (board is not null)
    {
      _applicationDbContext.Boards.Remove(board);
    }
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task<Board?> Get(BoardId id)
  {
    return await _applicationDbContext.Boards.FindAsync(id);
  }

  public async Task<List<Board>> GetAll()
  {
    return await _applicationDbContext.Boards.Where(b => b.DeletedAt == null).ToListAsync();
  }

  public async Task<Board> Update(Board entity)
  {
    _applicationDbContext.Boards.Update(entity);
    await _applicationDbContext.SaveChangesAsync();
    return entity;
  }

  public async Task<Board> AddMemberToBoard(BoardId boardId, Member member)
  {
    var board = await _applicationDbContext.Boards.FirstOrDefaultAsync(b => b.Id == boardId);
    if (board is null) return null;
    board.AddMember(member);

    await _applicationDbContext.SaveChangesAsync();
    return board;
  }

  public async Task<List<Member>> GetAllMembersByBoardId(BoardId boardId)
  {
    var board = await _applicationDbContext.Boards.FirstOrDefaultAsync(b => b.Id == boardId);
    if (board is null) return new List<Member>();
    
    return board.Members;
  }
}