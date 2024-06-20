using System.Reflection;
using FluentValidation;
using NSubstitute;
using Tasker.Application.Tasks.Commands;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Repositories;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Tests.Unit;

public class CreateAttachmentFileCommandTests
{
  [Fact]
  public async System.Threading.Tasks.Task CreateAttachmentFile_WithIncorrectContentType_Should_ThrowValidationException()
  {

    // Arrange
    var repository = Substitute.For<ITaskRepository>();  
    var command = new AddAttachmentFileCommand(
      new TaskId(Guid.NewGuid()), 
      "test", 
      "test.exe", 
      ""
    );
    var commandHandler = new AddAttachmentFileCommandHandler(repository);

    // Act & Assert
    await Assert.ThrowsAsync<ValidationException>(async () =>
    {
        await commandHandler.Handle(command, CancellationToken.None);
    });
  }

  [Fact]
  public async System.Threading.Tasks.Task CreateAttachmentFile_WithIncorrectFileSize_Should_ThrowValidationException()
  {
    string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
    string projectDirectory = Directory.GetParent(assemblyDirectory)!.Parent!.Parent!.FullName;
    string filePath = Path.Combine(projectDirectory, "Unit/AttachmentFiles/20MB-TESTFILE.pdf");
    byte[] fileBytes = File.ReadAllBytes(filePath);
    string base64String = Convert.ToBase64String(fileBytes);
    
    // Arrange
    var repository = Substitute.For<ITaskRepository>();  
    var command = new AddAttachmentFileCommand(
      new TaskId(Guid.NewGuid()), 
      "test", 
      "application/pdf", 
      base64String
    );
    var commandHandler = new AddAttachmentFileCommandHandler(repository);

    // Act & Assert
    await Assert.ThrowsAsync<ValidationException>(async () =>
    {
        await commandHandler.Handle(command, CancellationToken.None);
    });
  }
}