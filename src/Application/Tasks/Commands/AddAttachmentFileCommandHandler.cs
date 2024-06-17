using MediatR;
using Tasker.Domain.TaskAggregate;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Repositories;

namespace Tasker.Application.Tasks.Commands;

public class AddAttachmentFileCommandHandler : IRequestHandler<AddAttachmentFileCommand>
{
  private readonly ITaskRepository _taskRepository;

  public AddAttachmentFileCommandHandler(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }

  public async System.Threading.Tasks.Task Handle(AddAttachmentFileCommand request, CancellationToken cancellationToken)
  {
    var attachmentFile = AttachmentFile.Create(
      request.taskId, 
      request.name, 
      request.contentType, 
      request.base64
    );

    await _taskRepository.AddAttachmentFile(attachmentFile);
  }
}
