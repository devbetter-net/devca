
using Dev.Plugin.Auth.Core.Domain;
using Dev.Plugin.Auth.Core.Services;

namespace Dev.Plugin.Auth.Core.UseCases.Roles;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleDto>
{
    private readonly IRoleService _roleService;

    public GetRoleByIdQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        Role role = await _roleService.GetByIdAsync(request.Id);
        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description
        };
    }
}
