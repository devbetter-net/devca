
using Dev.Plugin.Auth.Core.Services;

namespace Dev.Plugin.Auth.Core.UseCases.Roles;

public class AddUserToRoleCommandHandler : IRequestHandler<AddUserToRoleCommand>
{
    private readonly IRoleService _roleService;
    private readonly IUserService _userService;

    public AddUserToRoleCommandHandler(IRoleService roleService,
                                       IUserService userService)
    {
        _roleService = roleService;
        _userService = userService;
    }

    public async Task Handle(AddUserToRoleCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddUserToRoleCommandValidator(_roleService, _userService);
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Count > 0)
        {
            throw new DevValidationException(validationResult);
        }

        await _roleService.AddUserToRoleAsync(request.RoleId, request.UserId);
    }
}
