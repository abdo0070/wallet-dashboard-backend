namespace Wallet.Helpers
{
    public class JWTOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public double ExpireAt { get; set; }
    
    }
}
