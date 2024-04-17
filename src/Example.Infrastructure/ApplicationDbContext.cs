using System.Reflection;
using Example.Application.Common;
using Example.Domain;
using Example.Domain.Entities;
using Example.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure;

public class ApplicationDbContext: IdentityDbContext<User, Role, long>, IContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    #region DbSetsRegistration

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    #endregion
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        builder.Ignore<IdentityUserToken<long>>();
        builder.Ignore<IdentityUserLogin<long>>();
        builder.Ignore<IdentityUserClaim<long>>();
        builder.Ignore<IdentityRoleClaim<long>>();
        
        builder.Entity<User>().ToTable("User");
        builder.Entity<Role>().ToTable("Rol");
        builder.Entity<IdentityUserRole<long>>().ToTable("UserRole");
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<IEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModified = DateTime.UtcNow;
                    break;
            }
        }
        
        return base.SaveChangesAsync(cancellationToken);
    }
}