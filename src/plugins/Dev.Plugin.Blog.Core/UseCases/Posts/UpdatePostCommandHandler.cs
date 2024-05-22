
namespace Dev.Plugin.Blog.Core.UseCases.Posts;
public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
{
    private readonly IPostService _postService;

    public UpdatePostCommandHandler(IPostService postService)
    {
        _postService = postService;
    }

    public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdatePostCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Count > 0)
        {
            throw new DevValidationException(validationResult);
        }
        Post post = new Post
        {
            Id = request.Id,
            Title = request.Title,
            Content = request.Content,
            MetaTitle = request.MetaTitle,
            MetaDescription = request.MetaDescription,
            MetaKeywords = request.MetaKeywords,
            IsPublished = request.IsPublished,
            DisplayOrder = request.DisplayOrder,
            UpdatedOnUtc = DateTime.UtcNow
        };
        Category category = await _postService.GetCategoryByIdAsync(request.CategoryId);
        CategoryPost categoryPost = new CategoryPost
        {
            PostId = request.Id,
            CategoryId = request.CategoryId,
            Post = post,
            Category = category
        };
        await _postService.UpdatePostAsync(categoryPost);
    }
}
