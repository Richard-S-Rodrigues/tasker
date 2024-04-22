namespace Tasker.Domain.Shared;

public abstract class Entity<TId> : IEquatable<Entity<TId>> 
  where TId : notnull
{
  protected Entity(TId id)
  {
    Id = id;
  }

  public TId Id { get; protected set; }
  [Newtonsoft.Json.JsonIgnore]
  public DateTime CreatedAt { get; set; }
  
  [Newtonsoft.Json.JsonIgnore]
  public string? CreatedBy { get; set; }
  
  [Newtonsoft.Json.JsonIgnore]
  public DateTime? UpdatedAt { get; set; }
  
  [Newtonsoft.Json.JsonIgnore]
  public string? UpdatedBy { get; set; }
  
  [Newtonsoft.Json.JsonIgnore]
  public DateTime? DeletedAt { get; set; }

  [Newtonsoft.Json.JsonIgnore]
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
}