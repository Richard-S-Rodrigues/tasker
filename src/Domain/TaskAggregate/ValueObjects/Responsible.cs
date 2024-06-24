using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.Shared;

namespace Tasker.Domain.TaskAggregate.ValueObjects;

public sealed class Responsible : ValueObject
{
  public Responsible(
    MemberId memberId,
    TimeOnly estimatedTime,
    TimeOnly time)
  {
    MemberId = memberId;
    EstimatedTime = estimatedTime;
    Time = time;
  }
  public MemberId MemberId { get; private set; }
  public TimeOnly? EstimatedTime { get; private set; }
  public TimeOnly? Time { get; private set; }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return MemberId;
    yield return EstimatedTime!;
    yield return Time!;
  }

  #pragma warning disable
  public Responsible() {}
  #pragma warning restore
}