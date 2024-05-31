namespace Dev.Plugin.Auth.Core.UseCases.Users;

public class GetUserListQuery : IRequest<List<UserDto>>
{
    public string SearchText { get; set; } = string.Empty;
}
