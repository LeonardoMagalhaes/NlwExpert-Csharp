using RocketSeatAuctionAPI.Communication.Requests;
using RocketSeatAuctionAPI.Entities;
using RocketSeatAuctionAPI.Interfaces;
using RocketSeatAuctionAPI.Services;

namespace RocketSeatAuctionAPI.UseCases.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IOfferRepository _offerRepository;

        public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository offerRepository)
        {
            _loggedUser = loggedUser;
            _offerRepository = offerRepository;
        }

        public int Execute(int itemId, RequestCreateOfferJson request)
        {
            var  user = _loggedUser.User();

            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id
            };

            _offerRepository.Add(offer);

            return offer.Id;
        }
    }
}
