

namespace Dev.Plugin.Blog.Core.UseCases.Categories;
public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryService _categoryService;

    public UpdateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCategoryCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Count > 0)
        {
            throw new DevValidationException(validationResult);
        }

        var category = await _categoryService.GetCategoryByIdAsync(request.Id);
        if (category == null)
        {
            throw new DevNotFoundException("Category not found", request.Id);
        }
        category.Name = request.Name;
        category.Description = request.Description;
        category.MetaTitle = request.MetaTitle;
        category.MetaDescription = request.MetaDescription;
        category.MetaKeywords = request.MetaKeywords;
        category.IsPublished = request.IsPublished;
        category.DisplayOrder = request.DisplayOrder;
        category.ParentId = request.ParentId;
        category.UpdatedOnUtc = DateTime.UtcNow;

        await _categoryService.UpdateCategoryAsync(category);
    }
}
