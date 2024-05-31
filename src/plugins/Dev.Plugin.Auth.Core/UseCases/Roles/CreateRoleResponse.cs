namespace Dev.Plugin.Auth.Core.UseCases.Roles;

public class CreateRoleResponse : BaseResponse
{
    public CreateRoleResponse() : base()
    {
        
    }
    public RoleDto Role { get; set; } = new();
}
