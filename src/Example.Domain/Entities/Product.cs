namespace Example.Domain.Entities;

public class Product: Entity<long>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
    
    public virtual Category Category { get; set; }
}