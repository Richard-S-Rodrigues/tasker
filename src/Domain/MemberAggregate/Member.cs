using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.MemberAggregate.ValueObjects;
using Tasker.Domain.Shared;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Domain.MemberAggregate;

public sealed class Member : AggregateRoot<MemberId>
{
  public Member(
    MemberId id,
    BoardId boardId,
    UserId userId,
    bool isAdmin) : base(id)
  {
    MemberId = id;
    BoardId = boardId;
    UserId = userId;
    IsAdmin = isAdmin;
  }
  public MemberId MemberId { get; private set; }
  public BoardId BoardId { get; private set; }
  public UserId UserId { get; private set; }
  public bool IsAdmin { get; private set; }
}