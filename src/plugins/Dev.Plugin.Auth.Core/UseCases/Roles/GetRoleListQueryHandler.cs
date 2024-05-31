
using Dev.Plugin.Auth.Core.Domain;
using Dev.Plugin.Auth.Core.Services;

namespace Dev.Plugin.Auth.Core.UseCases.Roles;

public class GetRoleListQueryHandler : IRequestHandler<GetRoleListQuery, List<RoleDto>>
{
    private readonly IRoleService _roleService;

    public GetRoleListQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<List<RoleDto>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {
        List<Role> roles = await _roleService.SearchRoleAsync(request.SearchText);
        return roles.Select(role => new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description
        }).ToList();
    }
}
