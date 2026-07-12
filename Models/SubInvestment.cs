namespace Wallet.Models
{
    public class SubInvestment
    {
        public int Id { get; set; }
        public float Amount { get; set; } = 0;
        public float Value { get; set; } = 0;
        public DateTime Created_at { get; set; } = DateTime.Now.Date;
        public DateTime Upated_at { get; set; } = DateTime.Now.Date;
        public int? InvestmentId { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }
        public Investment ?investment { get; set; }
    }
}
