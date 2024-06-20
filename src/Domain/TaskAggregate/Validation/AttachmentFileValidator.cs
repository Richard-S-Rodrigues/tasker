using FluentValidation;

namespace Tasker.Domain.TaskAggregate.Validation;

public class AttachmentFileValidator : AbstractValidator<AttachmentFile>
{
  private const int MaxFileSizeInBytes = 15 * 1024 * 1024; // 15 MB
  private static readonly List<string> AllowedMimeTypes = new List<string>
  {
      "application/pdf",
      "image/jpeg", 
      "image/png", 
      "image/gif",
      "text/plain",
      "application/msword", 
      "application/vnd.openxmlformats-officedocument.wordprocessingml.document" 
  };

  public AttachmentFileValidator()
  {
    RuleFor(attachmentFile => attachmentFile.ContentType)
    .Must(BeAValidFileType)
    .WithMessage("Tipo de arquivo não permitido. É apenas permitido fazer o upload de pdfs, imagens e documentos de texto.");

    RuleFor(attachmentFile => attachmentFile.Base64)
      .Must(BeAValidFileSize)
      .WithMessage($"Arquivo precisa ser menor que {MaxFileSizeInBytes / (1024 * 1024)} MB.");
  }

  private bool BeAValidFileType(string contentType)
  {
    if (contentType is null)
      return false;
      
    return AllowedMimeTypes.Contains(contentType);
  }

  private bool BeAValidFileSize(string base64File)
  {
      if (string.IsNullOrEmpty(base64File))
      {
          return false;
      }

      int paddingCount = base64File.Count(c => c == '=');
      int fileSizeInBytes = (int)(base64File.Length * 3 / 4) - paddingCount;

      return fileSizeInBytes <= MaxFileSizeInBytes;
  }
}