namespace Dev.Plugin.Auth.Core.UseCases.Authenticate;

public class SignInResponse : BaseResponse
{
    public SignInResponse() : base()
    {
        
    }
    public bool SignInSuccessfully { get; set; } = false;
    public string Token { get; set; } = string.Empty;
}
