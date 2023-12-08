namespace Infrastructure.Services.Authentication;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string SecretKey { get; init; } = string.Empty;
    public int ExpireMinutes { get; init; }
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
}
