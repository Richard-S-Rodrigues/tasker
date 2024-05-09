using FluentValidation;

namespace Tasker.Domain.TaskAggregate.Validation;

public class TaskValidator : AbstractValidator<Task>
{
  public TaskValidator()
  {
    RuleFor(task => task.Title).NotEmpty().WithMessage("Campo 'Título' é obrigatório.");
    RuleFor(task => task.Status).NotNull();
    RuleFor(task => task.Priority).NotNull();
    RuleFor(task => task.TimeDetails.StartDate).NotEmpty().WithMessage("Campo 'Data de ínicio' é obrigatório.");
    RuleFor(task => task.TimeDetails.EndDate).NotEmpty().WithMessage("Campo 'Data de fim' é obrigatório.");
    RuleFor(task => task.TimeDetails.EstimatedTime)
      .NotEmpty()
      .When(task => task.TimeDetails.Time != null)
      .WithMessage("Tempo estimado não especificado.");
  }
}