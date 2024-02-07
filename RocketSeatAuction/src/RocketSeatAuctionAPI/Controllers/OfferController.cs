using Microsoft.AspNetCore.Mvc;
using RocketSeatAuctionAPI.Communication.Requests;
using RocketSeatAuctionAPI.Filters;
using RocketSeatAuctionAPI.UseCases.Offers.CreateOffer;

namespace RocketSeatAuctionAPI.Controllers
{
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public class OfferController : RocketSeatAuctionBaseController
    {
        [HttpPost]
        [Route("{itemId}")]
        public IActionResult CreateOffer(
            [FromRoute]int itemId, 
            [FromBody] RequestCreateOfferJson request,
            [FromServices] CreateOfferUseCase useCase)
        {
            var id = useCase.Execute(itemId, request);

            return Created(string.Empty, id);
        }

    }
}
