
using Dev.Plugin.Auth.Core.Domain;
using Dev.Plugin.Auth.Core.Services;

namespace Dev.Plugin.Auth.Core.UseCases.Users;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUserService _userService;

    public GetUserByIdQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User? user = await _userService.GetUserByIdAsync(request.Id);
        if(user == null)
        {
            throw new DevNotFoundException(nameof(User), request.Id);
        }
        UserDto userDto = new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FullName = user.FullName,
        };
        return userDto;
    }
}
