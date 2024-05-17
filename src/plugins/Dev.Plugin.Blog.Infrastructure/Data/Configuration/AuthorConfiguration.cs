
namespace Dev.Plugin.Blog.Infrastructure.Data.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable(Constants.SCHEMA_NAME + nameof(Author));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Email).HasMaxLength(100);
    }
}
