namespace Dev.Plugin.Authen.Core.UseCases.Users;

public class CreateUserCommand : IRequest<CreateUserCommandResponse>
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
