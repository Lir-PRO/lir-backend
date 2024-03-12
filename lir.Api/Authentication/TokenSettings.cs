namespace Lir.Api.Authentication
{
    public class TokenSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessTokenExpirationMinutes { get; set; }
        public int RefreshTokenExpirationDays { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
