namespace Dev.Plugin.Blog.Infrastructure.Data.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(Constants.SCHEMA_NAME + nameof(Category));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(255);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.MetaTitle).HasMaxLength(100);
        builder.Property(x => x.MetaDescription).HasMaxLength(500);
        builder.Property(x => x.MetaKeywords).HasMaxLength(100);
        builder.HasMany(x => x.CategoryPosts)
               .WithOne(x => x.Category)
               .HasForeignKey(fk => fk.CategoryId);
    }
}
