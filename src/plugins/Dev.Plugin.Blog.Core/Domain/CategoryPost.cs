namespace Dev.Plugin.Blog.Core.Domain;

public class CategoryPost
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public Guid PostId { get; set; }
    public Post Post { get; set; } = null!;
}
