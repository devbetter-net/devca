using Dev.Plugin.Auth.Core;
using Dev.Plugin.Auth.Core.Domain;
using Dev.Plugin.Auth.Core.Services;
using Dev.Plugin.Auth.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dev.Plugin.Auth.Infrastructure.Services;

public class AuthenticateService : IAuthenticateService
{
    private readonly AuthenDbContext _context;

    public AuthenticateService(AuthenDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email.ToUpper() == email.ToUpper());
    }

    public async Task<UserPassword?> GetUserPasswordByUserIdAsync(Guid userId)
    {
        return await _context.UserPasswords.FirstOrDefaultAsync(x => x.UserId == userId);
    }
}
