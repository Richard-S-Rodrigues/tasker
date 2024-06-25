using MediatR;
using Tasker.Domain.TaskAggregate.Queries;
using Tasker.Infrastructure.Context;
using Dapper;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace Tasker.Application.Tasks.Queries;

public class GetCommentsByTaskIdQueryHandler : IRequestHandler<GetCommentsByTaskIdQuery, List<CommentDTO>>
{
  private readonly ApplicationDbContext _context;

  public GetCommentsByTaskIdQueryHandler(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<List<CommentDTO>> Handle(GetCommentsByTaskIdQuery request, CancellationToken cancellationToken)
  {
    var sql = @"
      SELECT 
        tc.id as Id,
        tc.text as Text,
        bm.id as MemberId,
        bm.name as MemberName,
        t.id as TaskId,
        tc.created_at as Date
      FROM task_comment tc
      join task t on t.id = tc.task_id
      join board_member bm on bm.board_id = t.board_id  
      where tc.task_id = @TaskId and tc.deleted_at is null
    ";
    var parameters = new { TaskId = request.TaskId.Value };
    
    using (var connection = new NpgsqlConnection(_context.Database.GetConnectionString()))
    {
      await connection.OpenAsync(cancellationToken);
      var comments = await connection.QueryAsync<CommentDTO>(sql, parameters);
      return comments.ToList();
    }
  }
}
