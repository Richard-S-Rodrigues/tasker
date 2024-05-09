namespace Tasker.Application.Shared;

public interface IUseCase<TInput, TOutput>
{
  Task<TOutput> Execute(TInput input); 
}