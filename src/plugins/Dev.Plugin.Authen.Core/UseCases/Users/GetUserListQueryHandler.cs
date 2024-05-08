
using Dev.Plugin.Authen.Core.Domain;
using Dev.Plugin.Authen.Core.Services;

namespace Dev.Plugin.Authen.Core.UseCases.Users;

public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserDto>>
{
    private readonly IUserService _userService;

    public GetUserListQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<List<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        List<User> users = await _userService.GetUserListAsync(request.SearchText);
        List<UserDto> userDtos = users.Select(user => new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FullName = user.FullName,
        }).ToList();

        return userDtos;
    }
}
