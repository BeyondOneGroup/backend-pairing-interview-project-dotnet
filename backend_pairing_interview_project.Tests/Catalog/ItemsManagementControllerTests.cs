using backend_pairing_interview_project.catalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Http.Results;
using Xunit;

namespace backend_pairing_interview_project.Tests.Catalog
{
    public class ItemsManagementControllerTests
    {
        private readonly Mock<ItemsService> _mockItemsService;
        private readonly ItemsManagementController _controller;

        public ItemsManagementControllerTests()
        {
            _mockItemsService = new Mock<ItemsService>(null, null);
            _controller = new ItemsManagementController(_mockItemsService.Object);
        }

        [Fact]
        public void GetInventory_ReturnsOkWithExpectedData()
        {
            var expectedList = new List<ItemsManagementLineDto>
            {
                new ItemsManagementLineDto()
            };
            _mockItemsService.Setup(s => s.GetAllItems()).Returns(expectedList);

            var result = _controller.GetInventory();
            var okResult = result as OkNegotiatedContentResult<List<ItemsManagementLineDto>>;

            Assert.IsNotNull(okResult);
            Assert.Equals(expectedList, okResult.Content);
            _mockItemsService.Verify(s => s.GetAllItems(), Times.Once);
        }

        [Fact]
        public void Upsert_ReturnsOkAndCallsAddItem()
        {
            var itemDto = ItemFixture.GetItemManagementItemDto();
            var lineDto = new ItemsManagementLineDto
            {
                Item = itemDto,
                Quantity = 3
            };
            var inputList = new List<ItemsManagementLineDto> { lineDto };

            var result = _controller.Upsert(inputList);
            var okResult = result as OkNegotiatedContentResult<List<ItemsManagementLineDto>>;

            Assert.IsNotNull(okResult);
            Assert.Equals(inputList.Count, okResult.Content.Count);
            Assert.Equals(lineDto.Quantity, okResult.Content[0].Quantity);
            Assert.Equals(lineDto.Item, okResult.Content[0].Item);

            _mockItemsService.Verify(s => s.AddItem(itemDto, 3), Times.Once);
        }

        [Fact]
        public void Delete_ReturnsOkAndCallsDelete()
        {
            var idsDto = new ItemIdsDto { Ids = new List<string> { "item1", "item2" } };

            var result = _controller.DeleteItems(idsDto);
            var okResult = result as OkNegotiatedContentResult<ItemIdsDto>;

            Assert.IsNotNull(okResult);
            Assert.Equals(idsDto, okResult.Content);
            _mockItemsService.Verify(s => s.Delete(idsDto), Times.Once);
        }
    }
}
