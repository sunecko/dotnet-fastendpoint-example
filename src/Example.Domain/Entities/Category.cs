namespace Example.Domain.Entities;

public class Category: Entity<long>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    
    public virtual ICollection<Product> Products { get; set; }
}