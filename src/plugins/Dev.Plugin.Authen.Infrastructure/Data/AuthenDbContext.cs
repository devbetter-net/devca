using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Dev.Plugin.Authen.Infrastructure.Data;

public class AuthenDbContext : DbContext
{

    public AuthenDbContext(DbContextOptions<AuthenDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("authen");
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
