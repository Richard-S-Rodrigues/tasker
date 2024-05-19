using Tasker.Domain.Shared;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate;

public sealed class AttachmentFile : Entity<AttachmentFileId>
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