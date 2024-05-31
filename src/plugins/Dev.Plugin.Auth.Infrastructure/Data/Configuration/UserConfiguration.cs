namespace Dev.Plugin.Auth.Infrastructure.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(Constants.SCHEMA_NAME + nameof(User));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Username).HasMaxLength(256);
        builder.Property(x => x.FullName).HasMaxLength(256);
        builder.Property(x => x.LastIpAddress).HasMaxLength(50);


        builder.HasMany(x => x.UserRoles)
               .WithOne(x => x.User)
               .HasForeignKey(fk => fk.UserId);

        builder.HasMany(x => x.UserPasswords)
               .WithOne(x => x.User)
               .HasForeignKey(fk => fk.UserId);

    }
}