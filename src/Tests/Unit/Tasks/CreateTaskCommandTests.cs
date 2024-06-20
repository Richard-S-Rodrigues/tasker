using FluentValidation;
using NSubstitute;
using Tasker.Application.Tasks.Commands;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Enums;
using Tasker.Domain.TaskAggregate.Repositories;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Tests.Unit;

public class CreateTaskCommandTests
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
      new TimeDetails(DateTime.Now, DateTime.Now.AddDays(1), 1, 1),
      Status.InRefinement,
      Priority.Low,
      new List<Responsible>());
    var commandHandler = new CreateTaskCommandHandler(repository);

    // Act & Assert
    await Assert.ThrowsAsync<ValidationException>(async () =>
    {
        await commandHandler.Handle(command, CancellationToken.None);
    });
  }

  [Fact]
  public async System.Threading.Tasks.Task CreateTask_WithTimeAndNotEstimatedTime_Should_ThrowValidationException()
  {
    // Arrange
    var repository = Substitute.For<ITaskRepository>();  
    var command = new CreateTaskCommand(
      new BoardId(Guid.NewGuid()),
      "task",
      "aaa",
      new TimeDetails(DateTime.Now, DateTime.Now.AddDays(1), 1, 0),
      Status.InRefinement,
      Priority.Low,
      new List<Responsible>());
    var commandHandler = new CreateTaskCommandHandler(repository);

    // Act & Assert
    await Assert.ThrowsAsync<ValidationException>(async () =>
    {
        await commandHandler.Handle(command, CancellationToken.None);
    });
  }

  [Fact]
  public async System.Threading.Tasks.Task CreateTask_WithStartDateGreaterThanEndDate_Should_ThrowValidationException()
  {
    // Arrange
    var repository = Substitute.For<ITaskRepository>();  
    var command = new CreateTaskCommand(
      new BoardId(Guid.NewGuid()),
      "task",
      "aaa",
      new TimeDetails(DateTime.Now.AddHours(1), DateTime.Now, 1, 1),
      Status.InRefinement,
      Priority.Low,
      new List<Responsible>());
    var commandHandler = new CreateTaskCommandHandler(repository);

    // Act & Assert
    await Assert.ThrowsAsync<ValidationException>(async () =>
    {
        await commandHandler.Handle(command, CancellationToken.None);
    });
  }
}

