using MediatR;

namespace Dev.Plugin.Authen.Core.UseCases.Authenticate;

public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInResponse>
{
    public async Task<SignInResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var response = new SignInResponse();
        var validator = new SignInCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
        {
            response.Success = false;
            foreach (var error in validationResult.Errors)
            {
                response.ValidationErrors.Add(error.ErrorMessage);
            }
        }
        if (response.Success)
        {
            // logic to authenticate user
        }
        return response;
    }
}
