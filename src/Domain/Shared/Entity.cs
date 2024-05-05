namespace Tasker.Domain.Shared;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
 where TId : notnull
{

  protected Entity(TId id)
  {
    Id = id;
  }
  
  public TId Id { get; protected set; }
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  
  public string? CreatedBy { get; set; }
  
  public DateTime? UpdatedAt { get; set; }
  
  public string? UpdatedBy { get; set; }
  
  public DateTime? DeletedAt { get; set; }

  public string? DeletedBy { get; set; }

  public bool IsDeleted() => DeletedAt.HasValue;

  public override bool Equals(object? obj)
  {
    return obj is Entity<TId> entity && Id.Equals(entity.Id);  
  }

  public static bool operator ==(Entity<TId> left, Entity<TId> right)
  {
    return Equals(left, right);
  }

  public static bool operator !=(Entity<TId> left, Entity<TId> right)
  {
    return !Equals(left, right);
  }

  public bool Equals(Entity<TId>? other)
  {
    return Equals((object?)other);
  }

  public override int GetHashCode()
  {
    return Id.GetHashCode();
  }

  
  #pragma warning disable
  protected Entity()
  {
  }
  #pragma warning restore
}