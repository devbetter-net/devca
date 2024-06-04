namespace Dev.Plugin.Blog.Core.Services;

public interface ICategoryService
{
    Task<Guid> CreateCategoryAsync(Category request);
    Task DeleteCategoryAsync(Guid id);
    Task<Category?> GetCategoryByIdAsync(Guid id);
    Task<bool> IsCategoryNameUniqueAsync(string name);
    Task UpdateCategoryAsync(Category category);
}
