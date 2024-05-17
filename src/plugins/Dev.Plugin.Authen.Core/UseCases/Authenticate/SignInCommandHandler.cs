using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Dev.Plugin.Authen.Core.Configurations;
using Dev.Plugin.Authen.Core.Domain;
using Dev.Plugin.Authen.Core.Services;


namespace Dev.Plugin.Authen.Core.UseCases.Authenticate;

public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInResponse>
{
    private readonly IAuthenticateService _authenticateService;
    private readonly JwtConfig _jwtConfig;

    public SignInCommandHandler(IAuthenticateService authenticateService,
                                IOptions<JwtConfig> jwtConfig)
    {
        _authenticateService = authenticateService;
        _jwtConfig = jwtConfig.Value;
    }

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
        if (!response.Success)
        {
            return response;
        }
        //get by email
        var user = await _authenticateService.GetUserByEmailAsync(request.Email);
        if (user == null)
        {
            return response;
        }
        //token
        response.SignInSuccessfully = true;
        response.Success = true; 
        response.Token = GenerateToken(user);

        return response;
    }

    private string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Email, user.Email),
                }),
            Expires = DateTime.UtcNow.AddMinutes(
                double.Parse(_jwtConfig.ExpirationInMinutes.ToString())),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
