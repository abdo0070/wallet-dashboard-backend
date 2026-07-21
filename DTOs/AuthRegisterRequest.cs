namespace Wallet.DTOs
{
    public class AuthRegisterRequest
    {
        public string Username { set; get; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
