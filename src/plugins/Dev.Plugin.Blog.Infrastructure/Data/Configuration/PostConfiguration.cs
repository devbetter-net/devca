
namespace Dev.Plugin.Blog.Infrastructure.Data.Configuration;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable(Constants.SCHEMA_NAME + nameof(Post));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(100);
        builder.Property(x => x.ShortDescription).HasMaxLength(1000);
        builder.Property(x => x.FullDescription).HasColumnType("ntext");
        builder.Property(x => x.Slug).HasMaxLength(100);
        builder.Property(x => x.MetaTitle).HasMaxLength(100);
        builder.Property(x => x.MetaDescription).HasMaxLength(1000);
        builder.Property(x => x.MetaKeywords).HasMaxLength(1000);
        builder.Property(x => x.ImageUrl).HasMaxLength(100);

        builder.HasMany(x => x.CategoryPosts)
               .WithOne(x => x.Post)
               .HasForeignKey(fk => fk.PostId);
    }
}
