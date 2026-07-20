namespace Wallet.Helpers
{
    public class JWTOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public string ExpireAt { get; set; }
    
    }
}
