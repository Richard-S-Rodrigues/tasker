using FluentValidation;

namespace Tasker.Domain.BoardAggregate.Validation;

public class BoardValidator : AbstractValidator<Board>
{
  public BoardValidator()
  {
    RuleFor(board => board.Name).NotEmpty().WithMessage("Campo 'Nome' é obrigatório.");
  }
}