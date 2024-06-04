namespace Dev.Plugin.Blog.Core.UseCases.Categories;

public class DeleteCategoryCommand : IRequest
{
    public Guid Id { get; set; }
}
