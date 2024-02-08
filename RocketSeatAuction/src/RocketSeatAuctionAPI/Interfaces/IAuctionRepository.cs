using RocketSeatAuctionAPI.Entities;

namespace RocketSeatAuctionAPI.Interfaces
{
    public interface IAuctionRepository
    {
        Auction? GetCurrent();
    }
}
