using Tasker.Domain.AttachmentFileAggregate.ValueObjects;
using Tasker.Domain.Shared;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.AttachmentFileAggregate;

public sealed class AttachmentFile : AggregateRoot<AttachmentFileId>
{
  private AttachmentFile(
    AttachmentFileId id,
    TaskId taskId,
    byte[] data
  ) : base(id)
  {
    TaskId = taskId;
    Data = data;
  }
  public TaskId TaskId { get; private set; }
  public byte[] Data { get; private set; }

  public static AttachmentFile Create(TaskId taskId, byte[] data)
  {
    return new AttachmentFile(new AttachmentFileId(Guid.NewGuid()), taskId, data);
  }

  #pragma warning disable
  public AttachmentFile() {}
  #pragma warning restore
}