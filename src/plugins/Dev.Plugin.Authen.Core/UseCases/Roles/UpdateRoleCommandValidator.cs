using Dev.Plugin.Authen.Core.Services;

namespace Dev.Plugin.Authen.Core.UseCases.Roles;

public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    private readonly IRoleService _roleService;
    public UpdateRoleCommandValidator(IRoleService roleService)
    {
        _roleService = roleService;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Role Name is required")
            .MaximumLength(256).WithMessage("Role Name maximum is 256 characters.");
        RuleFor(x => x.SystemName).MaximumLength(256).WithMessage("System Name maximum is 256 characters.");

        RuleFor(x => x)
            .MustAsync(RoleNameUniqueAsync).WithMessage("Role Name already exists");
    }

    private async Task<bool> RoleNameUniqueAsync(UpdateRoleCommand command, CancellationToken token)
    {
        return await _roleService.IsRoleNameUniqueAsync(command.Name);
    }
}
