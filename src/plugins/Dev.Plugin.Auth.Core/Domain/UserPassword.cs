namespace Dev.Plugin.Auth.Core.Domain;

public class UserPassword
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Password { get; set; } = string.Empty;
    public DateTime CreatedOnUtc { get; set; }
    public User User { get; set; } = default!;
}
