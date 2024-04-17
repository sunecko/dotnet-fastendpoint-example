namespace Example.Domain.Entities;

public class Entity<T>: Entity where T: struct
{
    public T Id { get; set; }
}

public class Entity : IEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModified { get; set; }
}