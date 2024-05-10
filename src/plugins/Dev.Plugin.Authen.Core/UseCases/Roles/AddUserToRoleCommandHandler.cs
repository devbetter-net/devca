
using Dev.Plugin.Authen.Core.Services;

namespace Dev.Plugin.Authen.Core.UseCases.Roles;

public class AddUserToRoleCommandHandler : IRequestHandler<AddUserToRoleCommand>
{
    private readonly IRoleService _roleService;

    public AddUserToRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task Handle(AddUserToRoleCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddUserToRoleCommandValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Count > 0)
        {
            throw new DevValidationException(validationResult);
        }

        await _roleService.AddUserToRoleAsync(request.RoleId, request.UserId);
    }
}
