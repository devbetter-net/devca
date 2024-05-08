using Dev.Plugin.Authen.Core;
using Dev.Plugin.Authen.Core.Domain;
using Dev.Plugin.Authen.Core.Services;
using Dev.Plugin.Authen.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dev.Plugin.Authen.Infrastructure.Services;

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
