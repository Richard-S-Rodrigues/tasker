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
      .NotEqual(0)
      .When(task => task.TimeDetails.Time > 0)
      .WithMessage("Tempo estimado não especificado.");
    
    RuleFor(task => task.TimeDetails.StartDate)
      .LessThanOrEqualTo(task => task.TimeDetails.EndDate)
      .WithMessage("Data de início não pode ser maior que a data de fim");
  }
}