using FluentValidation;
using Tasker.Domain.BoardAggregate.Validation;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.Shared;

namespace Tasker.Domain.BoardAggregate;

public sealed class Board : AggregateRoot<BoardId>
{
  public Board(
    BoardId id, 
    string name,
    List<Member> members) : base(id)
  {
    Name = name;
    Members = members;

    var validator = new BoardValidator();
    validator.ValidateAndThrow(this);
  }

  public string Name { get; private set; }
  public List<Member> Members { get; private set; }

  public static Board Create(string name, List<Member> members)
  {
    return new Board(new BoardId(Guid.NewGuid()), name, members);
  }

  public void AddMember(Member member)
  {
    Members.Add(member);
  }

  #pragma warning disable
  public Board() {}
  #pragma warning restore
} 