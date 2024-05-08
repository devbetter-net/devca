using MediatR;

namespace Dev.Plugin.Authen.Core.UseCases.Authenticate;

public class SignInCommand : IRequest<SignInResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
