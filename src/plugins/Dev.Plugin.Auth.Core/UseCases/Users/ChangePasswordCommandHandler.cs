
using Dev.Plugin.Auth.Core.Domain;
using Dev.Plugin.Auth.Core.Services;

namespace Dev.Plugin.Auth.Core.UseCases.Users;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand>
{
    private readonly IUserService _userService;

    public ChangePasswordCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserByIdAsync(request.UserId);
        if (user == null)
        {
            throw new DevNotFoundException(nameof(User), request.UserId);
        }

        if (await _userService.VerifyPasswordAsync(user, request.CurrentPassword))
        {
            UserPassword userPassword = new UserPassword
            {
                UserId = request.UserId,
                Password = request.NewPassword,
                CreatedOnUtc = DateTime.UtcNow,
                User = user
            };
            await _userService.CreateUserPasswordAsync(userPassword);
        }
        else
        {
            throw new DevBadRequestException("Current password is incorrect.");
        }
    }
}
