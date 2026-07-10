using Microsoft.EntityFrameworkCore;
using Wallet.Models;

namespace Wallet
{
    public class WalletContext : DbContext
    {
        public DbSet<User> users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlServer("Server=ABDALLA\\SQLEXPRESS;database=wallet;Integrated Security=True;TrustServerCertificate=True");
        
    }
}
