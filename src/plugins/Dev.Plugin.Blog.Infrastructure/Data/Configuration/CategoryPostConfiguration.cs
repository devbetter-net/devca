
namespace Dev.Plugin.Blog.Infrastructure.Data.Configuration;

public class CategoryPostConfiguration : IEntityTypeConfiguration<CategoryPost>
{
    public void Configure(EntityTypeBuilder<CategoryPost> builder)
    {
        builder.ToTable(Constants.SCHEMA_NAME + nameof(CategoryPost));
        builder.HasKey(x => new { x.PostId, x.CategoryId });

        builder.HasOne(x => x.Post)
               .WithMany(x => x.CategoryPosts)
               .HasForeignKey(fk => fk.PostId);

        builder.HasOne(x => x.Category)
               .WithMany(x => x.CategoryPosts)
               .HasForeignKey(fk => fk.CategoryId);
    }
}
