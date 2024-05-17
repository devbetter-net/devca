
namespace Dev.Plugin.Blog.Infrastructure.Data.Configuration;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable(Constants.SCHEMA_NAME + nameof(Post));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(255);
        builder.Property(x => x.MetaTitle).HasMaxLength(255);
        builder.Property(x => x.MetaDescription).HasMaxLength(1000);
        builder.Property(x => x.MetaKeywords).HasMaxLength(1000);

        builder.HasMany(x => x.CategoryPosts)
               .WithOne(x => x.Post)
               .HasForeignKey(fk => fk.PostId);
    }
}
