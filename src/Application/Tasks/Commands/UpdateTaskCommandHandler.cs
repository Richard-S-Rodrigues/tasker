using MediatR;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Repositories;

namespace Tasker.Application.Tasks.Commands;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
{
  private readonly ITaskRepository _taskRepository;

  public UpdateTaskCommandHandler(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }

  public async System.Threading.Tasks.Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
  {
    var task = new Domain.TaskAggregate.Task(
      request.Id,
      request.BoardId,
      request.Title,
      request.Description,
      request.TimeDetails,
      request.Status,
      request.Priority,
      request.AttachmentFiles,
      request.Comments,
      request.TaskChecklists
    );

    await _taskRepository.Update(task);
  }
}
