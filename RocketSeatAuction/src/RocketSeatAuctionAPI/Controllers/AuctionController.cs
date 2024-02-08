using Microsoft.AspNetCore.Mvc;
using RocketSeatAuctionAPI.Entities;
using RocketSeatAuctionAPI.UseCases.Auctions.GetCurrent;

namespace RocketSeatAuctionAPI.Controllers
{
    public class AuctionController : RocketSeatAuctionBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
        {
            var result = useCase.Execute();

            if (result is null)
                return NoContent();

            return Ok(result);
        }
    }
}
