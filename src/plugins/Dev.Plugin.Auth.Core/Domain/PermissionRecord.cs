namespace Dev.Plugin.Auth.Core.Domain;

public class PermissionRecord
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SystemName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public ICollection<RolePermission>? RolePermissions { get; set; }
}
