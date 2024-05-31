
namespace Dev.Plugin.Auth.Infrastructure.Data.Configuration;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable(Constants.SCHEMA_NAME + nameof(RolePermission));
        builder.HasKey(x => new { x.RoleId, x.PermissionRecordId });

        builder.HasOne(x => x.Role)
               .WithMany(x => x.RolePermissions)
               .HasForeignKey(fk => fk.RoleId);
               
        builder.HasOne(x => x.PermissionRecord)
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(fk => fk.PermissionRecordId);
    }
}
