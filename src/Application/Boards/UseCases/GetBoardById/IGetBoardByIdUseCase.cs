using Tasker.Application.Shared;
using Tasker.Domain.BoardAggregate.Queries;
using Tasker.Domain.BoardAggregate.ValueObjects;

namespace Tasker.Application.Boards.UseCases.GetBoardById;

public interface IGetBoardByIdUseCase : IUseCase<BoardId, BoardDTO>
{} 