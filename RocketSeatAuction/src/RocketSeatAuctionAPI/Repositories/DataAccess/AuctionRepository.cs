using Microsoft.EntityFrameworkCore;
using RocketSeatAuctionAPI.Entities;
using RocketSeatAuctionAPI.Interfaces;

namespace RocketSeatAuctionAPI.Repositories.DataAccess
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly RocketSeatAuctionDbContext _dbContext;

        public AuctionRepository (RocketSeatAuctionDbContext dbContext) => _dbContext = dbContext;

        public Auction? GetCurrent()
        {
            var today = DateTime.Now;

            return _dbContext
                .Auctions
                .Include(auction => auction.Items)
                .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
        }
    }
}
