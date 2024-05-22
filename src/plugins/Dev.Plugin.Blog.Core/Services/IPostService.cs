

namespace Dev.Plugin.Blog.Core.Services;

public interface IPostService
{
    Task CreatePostAsync(Post post);
    Task<Category> GetCategoryByIdAsync(Guid categoryId);
    Task UpdatePostAsync(CategoryPost categoryPost);
}
