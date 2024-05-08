namespace Dev.Plugin.Authen.Core.Domain;

public class RolePermission
{
    public Guid RoleId { get; set; }
    public Role Role { get; set; } = new();
    public Guid PermissionRecordId { get; set; }
    public PermissionRecord PermissionRecord { get; set; } = new();
}
