using Dev.Plugin.Authen.Core.Services;

namespace Dev.Plugin.Authen.Core.UseCases.Roles;

public class AddUserToRoleCommandValidator : AbstractValidator<AddUserToRoleCommand>
{
    private readonly IRoleService _roleService;
    private readonly IUserService _userService;
    public AddUserToRoleCommandValidator(IRoleService roleService, IUserService userService)
    {
        _roleService = roleService;
        _userService = userService;
        
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User Id is required");
        RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role Id is required");
        RuleFor(x => x.UserId).MustAsync(async (userId, cancellationToken) =>
        {
            var user = await _userService.GetUserByIdAsync(userId);
            return user != null;
        }).WithMessage("User does not exist");
        RuleFor(x => x.RoleId).MustAsync(async (roleId, cancellationToken) =>
        {
            var role = await _roleService.GetByIdAsync(roleId);
            return role != null;
        }).WithMessage("Role does not exist");

    }
}
