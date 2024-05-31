namespace Dev.Plugin.Auth.Core.UseCases.Users;

public class CreateUserCommandResponse : BaseResponse
{
    public CreateUserCommandResponse(Guid id) : base()
    {
        Id = id;
    }
    public Guid Id { get; set; }
}
