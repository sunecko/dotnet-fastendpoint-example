using Microsoft.AspNetCore.Identity;

namespace Example.Domain.Entities.Identity;

public class Role: IdentityRole<long>, IEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModified { get; set; }
}