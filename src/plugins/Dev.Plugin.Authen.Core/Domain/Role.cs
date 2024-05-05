namespace Dev.Plugin.Authen.Core.Domain;

public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Active { get; set; }
    public bool IsSystemRole { get; set; }
    public string SystemName { get; set; } = string.Empty;
    public ICollection<UserRole>? UserRoles { get; set; }
    public ICollection<RolePermission>? RolePermissions { get; set; }
}
