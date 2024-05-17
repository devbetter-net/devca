

namespace Dev.Plugin.Blog.Core.UseCases.Categories;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly ICategoryService _categoryService;

    public CreateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCategoryCommandValidator(_categoryService);
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Count > 0)
        {
            throw new DevValidationException(validationResult);
        }
        Category category = new Category
        {
            ParentId = request.ParentId,
            Name = request.Name,
            Description = request.Description,
            MetaTitle = request.MetaTitle,
            MetaDescription = request.MetaDescription,
            MetaKeywords = request.MetaKeywords,
            IsPublished = request.IsPublished,
            DisplayOrder = request.DisplayOrder,
            CreatedOnUtc = DateTime.UtcNow,
            UpdatedOnUtc = DateTime.UtcNow
        };

        return await _categoryService.CreateCategoryAsync(category);
    }
}