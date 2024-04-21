using Tasking.Domain.AttachmentFileAgggregate.ValueObjects;
using Tasking.Domain.Shared;
using Tasking.Domain.UserAggregate.ValueObjects;

namespace Tasking.Domain.TaskAggregate.ValueObjects;

public sealed class Comment : ValueObject
{
  public Comment(
    string text, 
    UserId userId, 
    List<AttachmentFileId> attachmentFileIds)
  {
    Text = text;
    UserId = userId;
    _attachmentFileIds = attachmentFileIds;
  }

  public string Text { get; private set; }
  public UserId UserId { get; private set; }
  public readonly List<AttachmentFileId> _attachmentFileIds = new(); 

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Text;
    yield return UserId;
    yield return _attachmentFileIds;      
  }
} 