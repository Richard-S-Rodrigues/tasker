using MediatR;
using Tasker.Domain.TaskAggregate;
using Tasker.Domain.TaskAggregate.Queries;
using Tasker.Domain.TaskAggregate.Repositories;

namespace Tasker.Application.Tasks.Queries;

public class GetAttachmentFileQueryHandler : IRequestHandler<GetAttachmentFileQuery, AttachmentFile>
{
  private readonly ITaskRepository _taskRepository;

  public GetAttachmentFileQueryHandler(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }

  public async Task<AttachmentFile> Handle(GetAttachmentFileQuery request, CancellationToken cancellationToken)
  {
    return await _taskRepository.GetAttachmentFile(request.taskId, request.attachmentFileId);
  }
}
