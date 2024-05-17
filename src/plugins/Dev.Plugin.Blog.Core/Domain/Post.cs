namespace Dev.Plugin.Blog.Core.Domain;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string MetaTitle { get; set; } = string.Empty;
    public string MetaDescription { get; set; } = string.Empty;
    public string MetaKeywords { get; set; } = string.Empty;
    public bool IsPublished { get; set; }
    public int DisplayOrder { get; set; }
    public DateTime PublishedDate { get; set; }
    public Guid AuthorId { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime UpdatedOnUtc { get; set; }
    public ICollection<CategoryPost>? CategoryPosts { get; set; }
}
