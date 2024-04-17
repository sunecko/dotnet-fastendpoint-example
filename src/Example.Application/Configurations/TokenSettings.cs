namespace Example.Application.Configurations;

public class TokenSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
    public int Expiration { get; set; }
}