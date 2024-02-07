using Microsoft.EntityFrameworkCore;
using RocketSeatAuctionAPI.Entities;

namespace RocketSeatAuctionAPI.Repositories
{
    public class RocketSeatAuctionDbContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\leonardo.alves\\Documents\\Estudos\\NlwExpert-Csharp\\RocketSeatAuction\\testDB\\leilaoDbNLW.db");
        }
    }
}
