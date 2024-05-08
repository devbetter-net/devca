using Dev.Plugin.Authen.Core.Domain;
using Dev.Plugin.Authen.Core.UseCases.Roles;

namespace Dev.Plugin.Authen.Core.Services;

public interface IRoleService
{
    Task CreateRoleAsync(Role role);
    Task<Role?> GetByIdAsync(Guid id);
    Task<bool> IsRoleNameUniqueAsync(string name);
    Task<List<Role>> SearchRoleAsync(string searchText);
    Task UpdateRoleAsync(UpdateRoleCommand request);
}
