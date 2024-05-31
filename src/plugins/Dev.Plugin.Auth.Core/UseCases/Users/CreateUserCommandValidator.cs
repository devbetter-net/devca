using Dev.Plugin.Auth.Core.Services;

namespace Dev.Plugin.Auth.Core.UseCases.Users;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    private readonly IUserService _userService;
    public CreateUserCommandValidator(IUserService userService)
    {
        _userService = userService;
        RuleFor(x => x.Username)
            .NotEmpty()
            .MaximumLength(50)
            .MustAsync(async (username, cancellationToken) =>
            {
                return await _userService.IsUsernameUniqueAsync(username);
            }).WithMessage("Username is already taken.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(256)
            .EmailAddress()
            .MustAsync(async (email, cancellationToken) =>
            {
                return await _userService.IsEmailUniqueAsync(email);
            }).WithMessage("Email is already taken.");         

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password minimum is 6 characters.")
            .MaximumLength(50).WithMessage("Password maximum is 50 characters.");
    }
}
