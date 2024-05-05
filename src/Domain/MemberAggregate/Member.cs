using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.MemberAggregate.ValueObjects;
using Tasker.Domain.Shared;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Domain.MemberAggregate;

public sealed class Member : AggregateRoot<MemberId>
{
  private Member(
    MemberId id,
    BoardId boardId,
    UserId userId,
    bool isAdmin) : base(id)
  {
    BoardId = boardId;
    UserId = userId;
    IsAdmin = isAdmin;
  }
  public BoardId BoardId { get; private set; }
  public UserId UserId { get; private set; }
  public bool IsAdmin { get; private set; }

  public static Member Create(BoardId boardId, UserId userId, bool isAdmin)
  {
    return new Member(new MemberId(Guid.NewGuid()), boardId, userId, isAdmin);
  }

  #pragma warning disable
  public Member() {}
  #pragma warning restore
}