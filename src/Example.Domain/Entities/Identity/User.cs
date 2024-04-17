using Microsoft.AspNetCore.Identity;

namespace Example.Domain.Entities.Identity;

public class User: IdentityUser<long>, IEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModified { get; set; }
}