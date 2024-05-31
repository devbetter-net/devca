using Dev.Plugin.Auth.Core.Services;

namespace Dev.Plugin.Auth.Core.UseCases.Roles;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    private readonly IRoleService _roleService;
    public CreateRoleCommandValidator(IRoleService roleService)
    {
        _roleService = roleService;


        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Role Name is required")
            .MaximumLength(256).WithMessage("Role Name maximum is 256 characters.");
        RuleFor(x => x.SystemName).MaximumLength(256).WithMessage("System Name maximum is 256 characters.");

        RuleFor(x => x)
            .MustAsync(RoleNameUniqueAsync).WithMessage("Role Name already exists");
    }

    private async Task<bool> RoleNameUniqueAsync(CreateRoleCommand command, CancellationToken token)
    {
        return await _roleService.IsRoleNameUniqueAsync(command.Name);
    }
}
