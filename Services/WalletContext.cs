using Microsoft.EntityFrameworkCore;
using Wallet.Models;

namespace Wallet.Services
{
    public class WalletContext : DbContext
    {        
        public DbSet<User> users { get; set; }
        public DbSet<Investment> investments { get; set; }
        public DbSet<InvestmentType> investmentTypes  { get; set; }
        public DbSet<SubInvestment> subInvestments{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlServer("Server=ABDALLA\\SQLEXPRESS;database=wallet;Integrated Security=True;TrustServerCertificate=True");
        
    }
}
