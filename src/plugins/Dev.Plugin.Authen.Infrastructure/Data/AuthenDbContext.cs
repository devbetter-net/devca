using System.Reflection;
namespace Dev.Plugin.Authen.Infrastructure.Data;

public class AuthenDbContext : DbContext
{
    public AuthenDbContext(DbContextOptions<AuthenDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public DbSet<User> Users { get; set; }
    public DbSet<UserPassword> UserPasswords { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<PermissionRecord> PermissionRecords { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
}
