
using Dev.Core.Exceptions;
using Dev.Plugin.Authen.Core.UseCases.Roles;
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

    public async Task<Role?> GetByIdAsync(Guid id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task<bool> IsRoleNameUniqueAsync(string name)
    {
        return await _context.Roles.AllAsync(x => x.Name != name);
    }

    public async Task<List<Role>> SearchRoleAsync(string searchText)
    {
        return await _context.Roles.Where(x => x.Name.Contains(searchText) ||
                                               x.SystemName.Contains(searchText) ||
                                               x.Description.Contains(searchText))
                                        .ToListAsync();
    }

    public async Task UpdateRoleAsync(UpdateRoleCommand request)
    {
        var role = await _context.Roles.FindAsync(request.Id);
        if (role == null)
        {
            throw new DevNotFoundException("Role not found", request.Id.ToString());
        }

        role.Name = request.Name;
        role.Description = request.Description;
        role.Active = request.Active;
        role.IsSystemRole = request.IsSystemRole;
        role.SystemName = request.SystemName;

        await _context.SaveChangesAsync();
    }
}
