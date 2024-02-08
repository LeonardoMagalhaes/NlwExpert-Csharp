using RocketSeatAuctionAPI.Entities;
using RocketSeatAuctionAPI.Interfaces;

namespace RocketSeatAuctionAPI.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCase
    {
        private readonly IAuctionRepository _repository;

        public GetCurrentAuctionUseCase(IAuctionRepository repository)
        {
            _repository = repository;
        }

        public Auction? Execute()
        {
            return _repository.GetCurrent();
        }
    }
}
