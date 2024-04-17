using Example.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Example.Api.Configurations;

public static class MigrationsSetup
{
    public static IServiceProvider ApplyMigrations(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var pendingMigration = db.Database.GetPendingMigrations();
        if (pendingMigration.Any())
        {
            db.Database.Migrate();
        }
        return serviceProvider;
    }
}