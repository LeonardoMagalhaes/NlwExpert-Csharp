using Microsoft.EntityFrameworkCore;
using RocketSeatAuctionAPI.Entities;
using RocketSeatAuctionAPI.Repositories;

namespace RocketSeatAuctionAPI.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCase
    {
        public Auction? Execute()
        {
            var repository = new RocketSeatAuctionDbContext();

            var today = DateTime.Now;

            return repository
                .Auctions
                .Include(auction => auction.Items)
                .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
        }
    }
}
