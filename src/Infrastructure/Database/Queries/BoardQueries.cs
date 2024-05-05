
using Tasker.Application.Boards.Queries;
using Tasker.Infrastructure.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Tasker.Domain.BoardAggregate.Queries;
using Tasker.Domain.BoardAggregate.ValueObjects;

namespace Tasker.Infrastructure.Database.Queries;

public class BoardQueries : IBoardQueries
{
  private readonly ApplicationDbContext _context;

  public BoardQueries(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<List<BoardDTO>> GetAllBoards()
  {
    var connection = _context.Database.GetDbConnection();
    var result = await connection.QueryAsync<dynamic>(
      @"
        SELECT
          b.id,
          b.name
        FROM board b
        WHERE b.deleted_at is null
        ORDER BY b.created_at DESC
      "
    );

    return result.Select(r => new BoardDTO(new BoardId(r.id), r.name)).ToList(); 
  }
}