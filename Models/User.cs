namespace Wallet.Models
{
    public class User
    {
        public int Id { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string Email { get; set; }
        public string Token { get; set; }
        public float Balance { get; set; } = 0;
        public float Invest_amount { get; set; } = 0;
    }
}
