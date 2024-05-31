namespace Dev.Plugin.Auth.Core.UseCases.Roles;

public class AddUserToRoleCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}
