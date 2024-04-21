namespace Tasking.Domain.TaskAggregate.Enums;

public enum Status 
{
  InRefinement = 0,
  Ready = 1,
  OnProgress = 2,
  Interrupted = 3,
  Canceled = 4,
  Done = 5
}