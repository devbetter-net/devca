using Dev.Plugin.Authen.Core.Domain;

namespace Dev.Plugin.Authen.Core.Services;

public interface IAuthenticateService
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<UserPassword?> GetUserPasswordByUserIdAsync(Guid userId);
}
