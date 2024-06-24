using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.Shared;

namespace Tasker.Domain.BoardAggregate;

public sealed class Member : Entity<MemberId>
{
  public Member(
    MemberId id,
    BoardId boardId,
    string name,
    bool isAdmin) : base(id)
  {
    BoardId = boardId;
    Name = name;
    IsAdmin = isAdmin;
  }
  public BoardId BoardId { get; private set; }
  public string Name { get; private set; }
  public bool IsAdmin { get; private set; }

  #pragma warning disable
  public Member() {}
  #pragma warning restore
}