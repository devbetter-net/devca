
using Dev.Plugin.Authen.Core.Domain;
using Dev.Plugin.Authen.Core.Services;

namespace Dev.Plugin.Authen.Core.UseCases.Roles;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreateRoleResponse>
{
    private readonly IRoleService _roleService;

    public CreateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public async Task<CreateRoleResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateRoleCommandValidator(_roleService);
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Count > 0)
        {
            throw new DevValidationException(validationResult);
        }

        var role = new Role
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Active = request.Active,
            IsSystemRole = request.IsSystemRole,
            SystemName = request.SystemName
        };

        await _roleService.CreateRoleAsync(role);

        var response = new CreateRoleResponse
        {
            Role = new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                Active = role.Active,
                IsSystemRole = role.IsSystemRole,
                SystemName = role.SystemName
            }
        };

        return response;
    }
}
