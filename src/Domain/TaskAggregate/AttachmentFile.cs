using Tasker.Domain.Shared;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate;

public sealed class AttachmentFile : Entity<AttachmentFileId>
{
  public AttachmentFile(
    AttachmentFileId id,
    TaskId taskId,
    string name,
    string contentType,
    string base64
  ) : base(id)
  {
    TaskId = taskId;
    Name = name;
    ContentType = contentType;
    Base64 = base64;
  }
  public TaskId TaskId { get; private set; }
  public string Name { get; private set; }
  public string ContentType { get; private set; }
  public string Base64 { get; private set; }

  public static AttachmentFile Create(TaskId taskId, string name, string contentType, string base64)
  {
    return new AttachmentFile(new AttachmentFileId(Guid.NewGuid()), taskId, name, contentType, base64);
  }

  #pragma warning disable
  public AttachmentFile() {}
  #pragma warning restore
}