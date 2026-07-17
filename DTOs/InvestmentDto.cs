using Wallet.Models;

namespace Wallet.DTOs
{
    public class InvestmentDto
    {
        public int Id { get; set; }
        public float Amount { get; set; } = 0;
        public float Value { get; set; } = 0;
        public DateTime Upated_at { get; set; } = DateTime.Now.Date;
        public int UserId { get; set; }
        public int InvestmentTypeId { get; set; }
    }
}
