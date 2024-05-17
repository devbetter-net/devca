
namespace Dev.Plugin.Blog.Core.UseCases.Posts;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
{
    private readonly IPostService _postService;
    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        Post post = new Post(){
            Id = Guid.NewGuid(),
            Title = request.Title,
            Content = request.Content,
            MetaTitle = request.MetaTitle,
            MetaDescription = request.MetaDescription,
            MetaKeywords = request.MetaKeywords,
            IsPublished = request.IsPublished,
            DisplayOrder = request.DisplayOrder,
            CreatedOnUtc = DateTime.UtcNow,
            UpdatedOnUtc = DateTime.UtcNow
        };
        await _postService.CreatePostAsync(post);
        return post.Id;
    }
}
