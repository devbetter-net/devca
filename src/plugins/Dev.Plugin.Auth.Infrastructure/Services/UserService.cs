using Dev.Plugin.Auth.Infrastructure.Data;

namespace Dev.Plugin.Auth.Infrastructure;

public class UserService : IUserService
{
    private readonly AuthenDbContext _context;

    public UserService(AuthenDbContext context)
    {
        _context = context;
    }

    public async Task CreateUserPasswordAsync(UserPassword userPassword)
    {
        await _context.UserPasswords.AddAsync(userPassword);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<List<User>> GetUserListAsync(string searchText)
    {
        return await _context.Users
                             .Where(user => user.Username.Contains(searchText) || user.Email.Contains(searchText))
                             .ToListAsync();
    }

    public async Task<bool> IsEmailUniqueAsync(string email)
    {
        return await _context.Users.AllAsync(user => user.Email.ToUpper() != email.ToUpper());
    }

    public async Task<bool> IsUsernameUniqueAsync(string username)
    {
        return await _context.Users.AllAsync(user => user.Username.ToUpper() != username.ToUpper());
    }

    public async Task<bool> VerifyPasswordAsync(User user, string currentPassword)
    {
        UserPassword? userPassword = await _context.UserPasswords
                                                  .Where(up => up.UserId == user.Id)
                                                  .OrderByDescending(up => up.CreatedOnUtc)
                                                  .FirstOrDefaultAsync();
        if (userPassword == null)
        {
            return false;
        }

        return userPassword.Password == currentPassword;
    }
}
