using Bogus;
using FluentAssertions;
using Moq;
using RocketSeatAuctionAPI.Entities;
using RocketSeatAuctionAPI.Enums;
using RocketSeatAuctionAPI.Interfaces;
using RocketSeatAuctionAPI.UseCases.Auctions.GetCurrent;
using Xunit;

namespace UseCase.Test.Auction.GetCurrent
{
    public class GetCurrentAuctionUseCaseTest
    {
        [Fact]
        public void Success()
        {
            // Arrange
            var fakeAuction = new Faker<RocketSeatAuctionAPI.Entities.Auction>()
                .RuleFor(auction => auction.Id, f => f.Random.Number(1, 700))
                .RuleFor(auction => auction.Name, f => f.Lorem.Word())
                .RuleFor(auction => auction.Starts, f => f.Date.Past())
                .RuleFor(auction => auction.Ends, f => f.Date.Future())
                .RuleFor(auction => auction.Items, (f, auction) => new List<Item>
                {
                    new Item
                    {
                        Id = f.Random.Number(1, 700),
                        Name = f.Commerce.ProductName(),
                        Brand = f.Commerce.Department(),
                        BasePrice = f.Random.Decimal(50, 1000),
                        Condition = f.PickRandom<Condition>(),
                        AuctionId = auction.Id
                    }
                }).Generate();

            var mock = new Mock<IAuctionRepository>();
            mock.Setup(i => i.GetCurrent()).Returns(fakeAuction);

            var useCase = new GetCurrentAuctionUseCase(mock.Object);

            // Act
            var result = useCase.Execute();

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(fakeAuction.Id);
            result.Name.Should().Be(fakeAuction.Name);
        }
    }
}
