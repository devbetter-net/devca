namespace Dev.Plugin.Auth.Infrastructure.Data.Configuration;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable(Constants.SCHEMA_NAME + nameof(UserRole));
        builder.HasKey(x => new { x.UserId, x.RoleId });

        builder.HasOne(x => x.Role)
               .WithMany(x => x.UserRoles)
               .HasForeignKey(fk => fk.RoleId);
        builder.HasOne(x => x.User)
               .WithMany(x => x.UserRoles)
               .HasForeignKey(fk => fk.UserId);
    }
}