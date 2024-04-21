using Tasking.Domain.AttachmentFileAgggregate.ValueObjects;
using Tasking.Domain.Shared;
using Tasking.Domain.TaskAggregate.ValueObjects;

namespace Tasking.Domain.AttachmentFileAgggregate;

public sealed class AttachmentFile : AggregateRoot<AttachmentFileId>
{
  public AttachmentFile(
    AttachmentFileId id,
    TaskId taskId,
    byte[] data
  ) : base(id)
  {
    AttachmentFileId = id;
    TaskId = taskId;
    Data = data;
  }
  public AttachmentFileId AttachmentFileId { get; private set; }
  public TaskId TaskId { get; private set; }
  public byte[] Data { get; private set; }
}