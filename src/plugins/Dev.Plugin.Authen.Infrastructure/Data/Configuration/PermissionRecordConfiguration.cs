namespace Dev.Plugin.Authen.Infrastructure.Data.Configuration;

public class PermissionRecordConfiguration : IEntityTypeConfiguration<PermissionRecord>
{
    public void Configure(EntityTypeBuilder<PermissionRecord> builder)
    {
        builder.ToTable(Constants.SCHEMA_NAME + nameof(PermissionRecord));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(256);
        builder.Property(x => x.SystemName).HasMaxLength(256);
        builder.Property(x => x.Category).HasMaxLength(256);
    }
}