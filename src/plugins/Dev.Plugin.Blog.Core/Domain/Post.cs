namespace Dev.Plugin.Blog.Core.Domain;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string FullDescription { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string MetaTitle { get; set; } = string.Empty;
    public string MetaDescription { get; set; } = string.Empty;
    public string MetaKeywords { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsPublished { get; set; }
    public int DisplayOrder { get; set; }
    public DateTime PublishedDate { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime UpdatedOnUtc { get; set; }
    public ICollection<CategoryPost>? CategoryPosts { get; set; }
}
