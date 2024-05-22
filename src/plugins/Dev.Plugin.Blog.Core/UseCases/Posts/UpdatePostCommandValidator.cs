namespace Dev.Plugin.Blog.Core.UseCases.Posts;

public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Post Id is required.");
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category Id is required.");
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(255).WithMessage("Title must not exceed 255 characters.");
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required.");
        RuleFor(x => x.MetaTitle)
            .MaximumLength(100).WithMessage("Meta Title must not exceed 100 characters.");
        RuleFor(x => x.MetaDescription)
            .MaximumLength(500).WithMessage("Meta Description must not exceed 500 characters.");
        RuleFor(x => x.MetaKeywords)
            .MaximumLength(100).WithMessage("Meta Keywords must not exceed 100 characters.");
    }
}
