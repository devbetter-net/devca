using Dev.Plugin.Auth.Core.Domain;

namespace Dev.Plugin.Auth.Core.Services;

public interface IAuthenticateService
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<UserPassword?> GetUserPasswordByUserIdAsync(Guid userId);
}
