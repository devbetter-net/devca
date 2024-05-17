
using Dev.Plugin.Authen.Core.Domain;
using Dev.Plugin.Authen.Core.Services;

namespace Dev.Plugin.Authen.Core.UseCases.Users;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateUserCommandValidator(_userService);
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Count > 0)
        {
            throw new DevValidationException(validationResult);
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            Email = request.Email,
            FullName = request.FullName,
            Active = true,
            Deleted = false,
            IsSystemAccount= false,
            LastIpAddress = null,
            CreatedOnUtc = DateTime.UtcNow,
            LastLoginDateUtc = null
        };

        var userPassword = new UserPassword
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Password = request.Password,
            CreatedOnUtc = DateTime.UtcNow,
            User = user
        };

        await _userService.CreateUserPasswordAsync(userPassword);
        return user.Id;
    }
}
