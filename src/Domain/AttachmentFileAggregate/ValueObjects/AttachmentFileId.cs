using Tasker.Domain.Shared;

namespace Tasker.Domain.AttachmentFileAgggregate.ValueObjects;

public sealed class AttachmentFileId : ValueObject
{
  public AttachmentFileId(long value)
  {
    Value = value;
  }
  public long Value { get; }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}