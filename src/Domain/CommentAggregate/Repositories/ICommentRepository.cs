using Tasker.Domain.CommentAggregate.ValueObjects;
using Tasker.Domain.Shared.Repository;

namespace Tasker.Domain.CommentAggregate.Repositories;

public interface ICommentRepository : IRepository<Comment, CommentId>
{

}