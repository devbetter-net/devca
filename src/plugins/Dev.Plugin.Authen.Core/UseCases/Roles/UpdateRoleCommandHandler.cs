
using Dev.Plugin.Authen.Core.Services;

namespace Dev.Plugin.Authen.Core.UseCases.Roles;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
{
    private readonly IRoleService _roleService;

    public UpdateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    
    public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateRoleCommandValidator(_roleService);
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Count > 0)
        {
            throw new DevValidationException(validationResult);
        }

        await _roleService.UpdateRoleAsync(request);
    }
}
