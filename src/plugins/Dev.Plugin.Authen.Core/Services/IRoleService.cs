using Dev.Plugin.Authen.Core.Domain;

namespace Dev.Plugin.Authen.Core.Services;

public interface IRoleService
{
    Task CreateRoleAsync(Role role);
    Task<bool> IsRoleNameUniqueAsync(string name);
}
