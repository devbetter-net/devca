
namespace Dev.Plugin.Authen.Core.Domain;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public bool Active { get; set; }
    public bool Deleted { get; set; }
    public bool IsSystemAccount { get; set; }
    public string? LastIpAddress { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? LastLoginDateUtc { get; set; }
    public ICollection<UserRole>? UserRoles { get; set; }
    public ICollection<UserPassword>? UserPasswords { get; set; }

}
