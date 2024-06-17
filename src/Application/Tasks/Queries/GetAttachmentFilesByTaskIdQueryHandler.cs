using MediatR;
using Tasker.Domain.TaskAggregate;
using Tasker.Domain.TaskAggregate.Queries;
using Tasker.Domain.TaskAggregate.Repositories;

namespace Tasker.Application.Tasks.Queries;

public class GetAttachmentFilesByTaskIdQueryHandler : IRequestHandler<GetAttachmentFilesByTaskIdQuery, List<AttachmentFile>>
{
  private readonly ITaskRepository _taskRepository;

  public GetAttachmentFilesByTaskIdQueryHandler(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }

  public async Task<List<AttachmentFile>> Handle(GetAttachmentFilesByTaskIdQuery request, CancellationToken cancellationToken)
  {
    return await _taskRepository.GetAttachmentFilesByTaskId(request.taskId);
  }
}
