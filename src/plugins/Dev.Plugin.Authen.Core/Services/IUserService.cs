using Dev.Plugin.Authen.Core.Domain;

namespace Dev.Plugin.Authen.Core.Services;

public interface IUserService
{
    Task CreateUserAsync(UserPassword userPassword);
    Task<User?> GetUserByIdAsync(Guid id);
    Task<List<User>> GetUserListAsync(string searchText);
    Task<bool> IsEmailUniqueAsync(string email);
    Task<bool> IsUsernameUniqueAsync(string username);
}
