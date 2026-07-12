using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Models
{
    public class Investment
    {
        public int Id { get; set; }
        public float Amount { get; set; } = 0;
        public float Value { get; set; } = 0;
        public DateTime Created_at { get; set; } = DateTime.Now.Date;
        public DateTime Upated_at { get; set; } = DateTime.Now.Date;
        public int UserId { get; set; }
        public int InvestmentTypeId { get; set; }
        public User ?user { get; set; }
        public InvestmentType ?investmentType { get; set; }
    }
}
