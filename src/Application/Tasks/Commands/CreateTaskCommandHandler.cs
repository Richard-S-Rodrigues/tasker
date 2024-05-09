using FluentValidation;
using MediatR;
using Tasker.Domain.AttachmentFileAggregate.ValueObjects;
using Tasker.Domain.CommentAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Enums;
using Tasker.Domain.TaskAggregate.Repositories;
using Tasker.Domain.TaskAggregate.Validation;

namespace Tasker.Application.Tasks.Commands;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand>
{
  private readonly ITaskRepository _taskRepository;

  public CreateTaskCommandHandler(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }

  public async Task Handle(CreateTaskCommand request, CancellationToken cancellationToken)
  {
    var task = Domain.TaskAggregate.Task.Create(
      request.boardId,
      request.title,
      request.description,
      request.timeDetails,
      Status.InRefinement,
      request.priority,
      request.responsibles,
      new List<AttachmentFileId>(),
      new List<CommentId>()
    );

    var validator = new TaskValidator();
    validator.ValidateAndThrow(task);

    await _taskRepository.Add(task);
  }
}
