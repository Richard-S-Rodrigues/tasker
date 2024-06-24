using FluentValidation;
using NSubstitute;
using Tasker.Application.Boards.Commands;
using Tasker.Domain.BoardAggregate.Commands;
using Tasker.Domain.BoardAggregate.Repositories;

namespace Tasker.Tests.Unit;

public class CreateBoardCommandTests
{
  [Fact]
  public async System.Threading.Tasks.Task CreateBoard_NoName_Should_ThrowValidationException()
  {
    // Arrange
    var repository = Substitute.For<IBoardRepository>();  
    var command = new CreateBoardCommand(
      "",
      Guid.NewGuid(), 
      ""
    );
    var commandHandler = new CreateBoardCommandHandler(repository);

    // Act & Assert
    await Assert.ThrowsAsync<ValidationException>(async () =>
    {
        await commandHandler.Handle(command, CancellationToken.None);
    });
  }
}

