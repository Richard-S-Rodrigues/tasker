using FluentValidation;
using NSubstitute;
using Tasker.Application.Tasks.Commands;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Repositories;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Tests.Unit.Task;

public class TaskCommandTests
{
  [Fact]
  public async System.Threading.Tasks.Task CreateTask_NoTitle_Should_ThrowValidationException()
  {

    // Arrange
    var repository = Substitute.For<ITaskRepository>();  
    var command = new CreateTaskCommand(
      new BoardId(Guid.NewGuid()),
      "",
      "aaa",
      new TimeDetails(DateTime.UtcNow, new DateTime().AddDays(1), null, null),
      0,
      new List<Responsible>());
    var commandHandler = new CreateTaskCommandHandler(repository);

    // Act & Assert
    await Assert.ThrowsAsync<ValidationException>(async () =>
    {
        await commandHandler.Handle(command, CancellationToken.None);
    });
  }
}

