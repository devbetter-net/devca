namespace Dev.Plugin.Auth.Core.Domain;

public class UserRole 
{
    public Guid UserId { get; set; }
    public User User { get; set; } = new();
    public Guid RoleId { get; set; }
    public Role Role { get; set; } = new();
}