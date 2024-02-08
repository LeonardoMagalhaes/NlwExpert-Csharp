using Bogus;
using FluentAssertions;
using Moq;
using RocketSeatAuctionAPI.Communication.Requests;
using RocketSeatAuctionAPI.Interfaces;
using RocketSeatAuctionAPI.UseCases.Offers.CreateOffer;
using Xunit;

namespace UseCase.Test.Offer.CreateOffer
{
    public class CreateOfferUseCaseTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Success(int itemId)
        {
            // Arrange
            var fakeRequest = new Faker<RequestCreateOfferJson>()
                .RuleFor(request => request.Price, f => f.Random.Decimal(1, 700)).Generate();

            var mockOfferRepository = new Mock<IOfferRepository>();
            var mockLoggedUser = new Mock<ILoggedUser>();
            mockLoggedUser.Setup(i => i.User()).Returns(new RocketSeatAuctionAPI.Entities.User());

            var useCase = new CreateOfferUseCase(mockLoggedUser.Object, mockOfferRepository.Object);

            // Act
            var act = () => useCase.Execute(itemId, fakeRequest);

            // Assert
            act.Should().NotThrow();
        }
    }
}
