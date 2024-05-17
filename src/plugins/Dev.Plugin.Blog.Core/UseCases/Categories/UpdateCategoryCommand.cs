namespace Dev.Plugin.Blog.Core.UseCases.Categories;

public class UpdateCategoryCommand : IRequest
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string MetaTitle { get; set; } = string.Empty;
    public string MetaDescription { get; set; } = string.Empty;
    public string MetaKeywords { get; set; } = string.Empty;
    public bool IsPublished { get; set; }
    public int DisplayOrder { get; set; }
}
