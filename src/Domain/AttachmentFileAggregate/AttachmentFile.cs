using Tasker.Domain.AttachmentFileAgggregate.ValueObjects;
using Tasker.Domain.Shared;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.AttachmentFileAgggregate;

public sealed class AttachmentFile : AggregateRoot<AttachmentFileId>
{
  public AttachmentFile(
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

  #pragma warning disable
  public AttachmentFile() {}
  #pragma warning restore
}