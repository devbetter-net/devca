namespace Dev.Plugin.Auth.Core.UseCases.Roles;

public class GetRoleListQuery : IRequest<List<RoleDto>>
{
    public GetRoleListQuery()
    {
    }

    public string SearchText { get; set; } = string.Empty;
}
