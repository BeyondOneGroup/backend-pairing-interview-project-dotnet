using backend_pairing_interview_project.offers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Xunit;

namespace backend_pairing_interview_project.Tests.Offers
{
    public class OfferManagementControllerTests
    {
        private readonly Mock<OfferStore> _mockOfferStore;
        private readonly OfferManagementController _controller;

        public OfferManagementControllerTests()
        {
            _mockOfferStore = new Mock<OfferStore>();
            _controller = new OfferManagementController(_mockOfferStore.Object);
        }

        [Fact]
        public void GetOffers_ReturnsOkWithExpectedData()
        {
            var dto = OfferFixture.GetOfferOne().ToOffersManagementOfferDto();
            var expectedList = new List<OffersManagementOfferDto> { dto };
            _mockOfferStore.Setup(s => s.GetAllManagementOffers()).Returns(expectedList);

            var actionResult = _controller.GetOffers();
            var result = actionResult as OkNegotiatedContentResult<List<OffersManagementOfferDto>>;

            Assert.IsNotNull(result);
            var value = result.Content;
            Assert.IsNotNull(value);
            Assert.Equals(expectedList.Count, value.Count);
            AssertEqual(dto, value.First());

            _mockOfferStore.Verify(s => s.GetAllManagementOffers(), Times.Once);
        }

        [Fact]
        public void Upsert_CallsAddOffersAndReturnsOk()
        {
            var dto = OfferFixture.GetOfferOne().ToOffersManagementOfferDto();
            var list = new List<OffersManagementOfferDto> { dto };

            var actionResult = _controller.GetOffers();
            var result = actionResult as OkNegotiatedContentResult<List<OffersManagementOfferDto>>;

            Assert.IsNotNull(result);
            var value = result.Content;
            Assert.IsNotNull(value);
            AssertEqual(dto, value.First());

            _mockOfferStore.Verify(s => s.AddOffers((IEnumerable<OffersManagementOfferDto>)It.IsAny<OffersManagementOfferDto>()), Times.Once);
        }

        [Fact]
        public void Delete_CallsDeleteOnOfferStore()
        {
            var offer = OfferFixture.GetOfferOne();
            var id = offer.Id;
            var dto = new OfferIdsDto();
            dto.Ids.Add(id);

            _controller.Delete(dto);

            _mockOfferStore.Verify(s => s.Delete(id), Times.Once);
        }

        private void AssertEqual(OffersManagementOfferDto expected, OffersManagementOfferDto actual)
        {
            Assert.Equals(expected.Id, actual.Id);
            Assert.Equals(expected.Name, actual.Name);
            Assert.Equals(expected.Description, actual.Description);
            Assert.Equals(expected.ItemId, actual.ItemId);
            Assert.Equals(expected.PriceReduction, actual.PriceReduction);
            Assert.Equals(expected.QuantityThreshold, actual.QuantityThreshold);
        }
    }
}
