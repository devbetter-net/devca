
namespace Dev.Plugin.Blog.Core.Services;

public interface IPostService
{
    Task CreatePostAsync(Post post);
}
