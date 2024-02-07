using Microsoft.AspNetCore.Mvc;
using RocketSeatAuctionAPI.Entities;
using RocketSeatAuctionAPI.UseCases.Auctions.GetCurrent;

namespace RocketSeatAuctionAPI.Controllers
{
    public class AuctionController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction()
        {
            var useCase = new GetCurrentAuctionUseCase();

            var result = useCase.Execute();

            if (result is null)
                return NoContent();

            return Ok(result);
        }
    }
}
