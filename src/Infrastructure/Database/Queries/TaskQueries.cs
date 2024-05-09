
using Tasker.Application.Tasks.Queries;
using Tasker.Infrastructure.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Infrastructure.Database.Queries;

public class TaskQueries : ITaskQueries
{
  private readonly ApplicationDbContext _context;

  public TaskQueries(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<List<Domain.TaskAggregate.Task>> GetAllTasksByBoardId(Guid boardId)
  {
    var connection = _context.Database.GetDbConnection();
    var result = await connection.QueryAsync<dynamic>(
      @"
        SELECT
          *
        FROM task t
        WHERE t.deleted_at is null
        and t.board_id = @boardId
        ORDER BY t.created_at DESC
      ",
      new { boardId }
    );

    return result.Select(r => 
      new Domain.TaskAggregate.Task(
        new TaskId(r.id), 
        r.boardId,
        r.title,
        r.description,
        r.timeDetails,
        r.status,
        r.priority,
        r.responsibles,
        r.attachmentFileIds,
        r.commentIds
        )
      ).ToList();
  }
}