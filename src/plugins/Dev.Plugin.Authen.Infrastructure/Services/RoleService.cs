
using Dev.Plugin.Authen.Infrastructure.Data;

namespace Dev.Plugin.Authen.Infrastructure.Services;

public class RoleService : IRoleService
{
    private readonly AuthenDbContext _context;

    public RoleService(AuthenDbContext context)
    {
        _context = context;
    }

    public async Task CreateRoleAsync(Role role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsRoleNameUniqueAsync(string name)
    {
        return await _context.Roles.AllAsync(x => x.Name != name);
    }
}
