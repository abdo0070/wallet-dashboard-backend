namespace Wallet.DTOs
{
    public class UserDto
    {
        public string Id { set; get; }
        public string Username { set; get; }
        public string Email { get; set; }
        public string Token { get; set; } = "";
        public float Balance { get; set; } = 0;
        public float Invest_amount { get; set; } = 0;

    }
}
