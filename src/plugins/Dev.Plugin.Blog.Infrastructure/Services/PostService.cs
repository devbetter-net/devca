

namespace Dev.Plugin.Blog.Infrastructure.Services;

public class PostService : IPostService
{
    private readonly BlogDbContext _dbContext;

    public PostService(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreatePostAsync(Post post)
    {
        await _dbContext.Posts.AddAsync(post);
    }

    public async Task<Category> GetCategoryByIdAsync(Guid categoryId)
    {
        return await _dbContext.Categories.AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == categoryId) ?? new Category();
    }

    public async Task UpdatePostAsync(CategoryPost categoryPost)
    {
        _dbContext.CategoryPosts.Update(categoryPost);
        await _dbContext.SaveChangesAsync();
    }
}
