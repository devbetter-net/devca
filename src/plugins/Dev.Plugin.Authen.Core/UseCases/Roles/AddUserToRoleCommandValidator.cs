using Dev.Plugin.Authen.Core.Services;

namespace Dev.Plugin.Authen.Core.UseCases.Roles;

public class AddUserToRoleCommandValidator : AbstractValidator<AddUserToRoleCommand>
{

    public AddUserToRoleCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User Id is required");
        RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role Id is required");        
    
    }
}
