using backend_pairing_interview_project.offers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Http.Results;
using Xunit;

namespace backend_pairing_interview_project.Tests.Offers
{
    public class OfferControllerTests
    {
        private readonly Mock<OfferStore> _mockOfferStore;
        private readonly OfferController _controller;

        public OfferControllerTests()
        {
            _mockOfferStore = new Mock<OfferStore>();
            _controller = new OfferController(_mockOfferStore.Object);
        }

        [Fact]
        public void GetOffers_ReturnsOkWithExpectedOffers()
        {
            var offerDto = OfferFixture.GetOfferOne().ToOfferDto();
            var expectedList = new List<OfferDto> { offerDto };

            _mockOfferStore.Setup(x => x.GetAllOffers()).Returns(expectedList);

            var actionResult = _controller.GetOffers();
            var result = actionResult as OkNegotiatedContentResult<List<OfferDto>>;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);

            var actualList = result.Content;

            Assert.Equals(expectedList.Count, actualList.Count);

            for (int i = 0; i < actualList.Count; i++)
            {
                var expected = expectedList[i];
                var actual = actualList[i];

                Assert.Equals(expected.Id, actual.Id);
                Assert.Equals(expected.Name, actual.Name);
                Assert.Equals(expected.Description, actual.Description);
                Assert.Equals(expected.ItemId, actual.ItemId);
                Assert.Equals(expected.QuantityThreshold, actual.QuantityThreshold);
                Assert.Equals(expected.PriceReduction, actual.PriceReduction);
            }

            _mockOfferStore.Verify(x => x.GetAllOffers(), Times.Once);
        }
    }
}
