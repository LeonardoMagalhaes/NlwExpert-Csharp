using Microsoft.EntityFrameworkCore;
using RocketSeatAuctionAPI.Entities;

namespace RocketSeatAuctionAPI.Repositories
{
    public class RocketSeatAuctionDbContext : DbContext
    {
        public RocketSeatAuctionDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
