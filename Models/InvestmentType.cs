namespace Wallet.Models
{
    public class InvestmentType
    {
        public int Id { get; set; }
        public string Platform { get; set; }
        public string Type { get; set; }
        ICollection<Investment> ?investments { get; set; }
    }
}
