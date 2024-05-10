using Dev.Plugin.Authen.Core.Domain;

namespace Dev.Plugin.Authen.Core.Services;

public interface IUserService
{
    Task CreateUserPasswordAsync(UserPassword userPassword);
    Task<User?> GetUserByIdAsync(Guid id);
    Task<List<User>> GetUserListAsync(string searchText);
    Task<bool> IsEmailUniqueAsync(string email);
    Task<bool> IsUsernameUniqueAsync(string username);
    Task<bool> VerifyPasswordAsync(User user, string currentPassword);
}
