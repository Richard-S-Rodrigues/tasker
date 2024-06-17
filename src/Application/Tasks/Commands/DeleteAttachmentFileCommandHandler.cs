using MediatR;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Repositories;

namespace Tasker.Application.Tasks.Commands;

public class DeleteAttachmentFileCommandHandler : IRequestHandler<DeleteAttachmentFileCommand>
{
  private readonly ITaskRepository _taskRepository;

  public DeleteAttachmentFileCommandHandler(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }

  public async System.Threading.Tasks.Task Handle(DeleteAttachmentFileCommand request, CancellationToken cancellationToken)
  {
    await _taskRepository.DeleteAttachmentFile(request.attachmentFile);
  }
}
