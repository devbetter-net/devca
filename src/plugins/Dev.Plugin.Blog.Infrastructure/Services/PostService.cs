
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
        await _dbContext.SaveChangesAsync();
    }
}
