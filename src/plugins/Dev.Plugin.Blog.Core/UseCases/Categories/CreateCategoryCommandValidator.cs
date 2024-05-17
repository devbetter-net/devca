namespace Dev.Plugin.Blog.Core.UseCases.Categories;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    private readonly ICategoryService _categoryService;
    public CreateCategoryCommandValidator(ICategoryService categoryService)
    {
        _categoryService = categoryService;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category Name is required")
            .MaximumLength(256).WithMessage("Category Name maximum is 256 characters.");
        RuleFor(x => x)
            .MustAsync(CategoryNameUniqueAsync).WithMessage("Category Name already exists");
    }

    private async Task<bool> CategoryNameUniqueAsync(CreateCategoryCommand command, CancellationToken token)
    {
        return await _categoryService.IsCategoryNameUniqueAsync(command.Name);
    }
}
