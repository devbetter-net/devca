namespace Dev.Plugin.Blog.Core.Services;

public interface ICategoryService
{
    Task<Guid> CreateCategoryAsync(Category request);
    Task<Category?> GetCategoryByIdAsync(Guid id);
    Task<bool> IsCategoryNameUniqueAsync(string name);
    Task UpdateCategoryAsync(Category category);
}
