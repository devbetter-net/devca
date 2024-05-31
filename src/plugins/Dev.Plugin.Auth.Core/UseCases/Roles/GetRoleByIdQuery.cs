namespace Dev.Plugin.Auth.Core.UseCases.Roles;

public class GetRoleByIdQuery : IRequest<RoleDto>
{
    public Guid Id { get; set; }
    public GetRoleByIdQuery(Guid id)
    {
        Id = id;
    }
}
