namespace Example.Domain;

public interface IEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModified { get; set; }
}