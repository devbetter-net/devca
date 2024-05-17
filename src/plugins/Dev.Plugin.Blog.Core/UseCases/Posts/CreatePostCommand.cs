namespace Dev.Plugin.Blog.Core.UseCases.Posts;

public class CreatePostCommand : IRequest<Guid>
{
    public Guid? CategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public string? MetaKeywords { get; set; }
    public bool IsPublished { get; set; }
    public int DisplayOrder { get; set; }
}
