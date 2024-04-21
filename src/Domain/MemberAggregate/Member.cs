using Tasking.Domain.BoardAggregate.ValueObjects;
using Tasking.Domain.MemberAggregate.ValueObjects;
using Tasking.Domain.Shared;
using Tasking.Domain.UserAggregate.ValueObjects;

namespace Tasking.Domain.MemberAggregate;

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