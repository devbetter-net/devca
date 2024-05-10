namespace Dev.Plugin.Authen.Core.Configurations;

public class JwtConfig
{
    public string Authority { get; set; } = string.Empty;
    public string Audiences { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Secret { get; set; } = string.Empty;
    public int ExpirationInMinutes { get; set; }
}
