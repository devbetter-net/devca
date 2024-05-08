namespace Dev.Plugin.Authen.Core.UseCases.Roles;

public class RoleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Active { get; set; }
    public bool IsSystemRole { get; set; }
    public string SystemName { get; set; } = string.Empty;
}
