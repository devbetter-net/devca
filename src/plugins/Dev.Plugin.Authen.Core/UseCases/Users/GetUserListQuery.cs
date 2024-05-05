namespace Dev.Plugin.Authen.Core.UseCases.Users;

public class GetUserListQuery : IRequest<List<UserDto>>
{
    public string SearchText { get; set; } = string.Empty;
}
