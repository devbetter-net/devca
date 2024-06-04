using Dev.Core.Exceptions;

namespace Dev.Plugin.Blog.Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly BlogDbContext _dbContext;

    public CategoryService(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> CreateCategoryAsync(Category category)
    {
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();
        return category.Id;
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        var categoryToDelete = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (categoryToDelete == null)
        {
            throw new DevNotFoundException($"Category not found", id);
        }
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid id)
    {
        return await _dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> IsCategoryNameUniqueAsync(string name)
    {
        return await _dbContext.Categories.AllAsync(x => x.Name != name);
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        _dbContext.Categories.Update(category);
        await _dbContext.SaveChangesAsync();
    }
}
