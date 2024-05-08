namespace Dev.Plugin.Authen.Infrastructure.Data.Configuration;

public class UserPasswordConfiguration : IEntityTypeConfiguration<UserPassword>
{
    public void Configure(EntityTypeBuilder<UserPassword> builder)
    {
        builder.ToTable(Constants.SCHEMA_NAME + nameof(UserPassword));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Password).HasMaxLength(1000);

        builder.HasOne(x => x.User)
               .WithMany(x => x.UserPasswords)
               .HasForeignKey(fk => fk.UserId);
    }
}