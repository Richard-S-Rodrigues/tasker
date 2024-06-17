using Tasker.Domain.TaskAggregate;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Web.Pages.Tasks.ViewModels;

public class AttachmentFileViewModel 
{
  public Guid? Id { get; set; }
  public Guid TaskId { get; set; }
  public string Name { get; set; }
  public string ContentType { get; set; }
  public string Base64 { get; set; }

  public static AttachmentFileViewModel ToViewModel(AttachmentFile attachmentFile)
  {
    return new AttachmentFileViewModel()
    {
      Id = attachmentFile.Id.Value,
      TaskId = attachmentFile.TaskId.Value,
      Name = attachmentFile.Name,
      ContentType = attachmentFile.ContentType,
      Base64 = attachmentFile.Base64
    };
  }

  public static AttachmentFile ToEntity(AttachmentFileViewModel attachmentFileViewModel)
  {
    if (attachmentFileViewModel.Id.HasValue)
    {
      return new AttachmentFile(
        new AttachmentFileId(attachmentFileViewModel.Id.Value),
        new Domain.TaskAggregate.ValueObjects.TaskId(attachmentFileViewModel.TaskId),
        attachmentFileViewModel.Name,
        attachmentFileViewModel.ContentType,
        attachmentFileViewModel.Base64);
    }

    return AttachmentFile.Create(
      new Domain.TaskAggregate.ValueObjects.TaskId(attachmentFileViewModel.TaskId),
      attachmentFileViewModel.Name,
      attachmentFileViewModel.ContentType,
      attachmentFileViewModel.Base64);
  }

  public static IEnumerable<AttachmentFileViewModel> ToEnumerableViewModel(IEnumerable<AttachmentFile> attachmentFiles)
  {
    return attachmentFiles.Select(attachmentFile => ToViewModel(attachmentFile));
  }

  public static IEnumerable<AttachmentFile> ToEnumerableEntity(IEnumerable<AttachmentFileViewModel> attachmentFileViewModels)
  {
    return attachmentFileViewModels.Select(attachmentFileViewModel => ToEntity(attachmentFileViewModel));
  }
}
