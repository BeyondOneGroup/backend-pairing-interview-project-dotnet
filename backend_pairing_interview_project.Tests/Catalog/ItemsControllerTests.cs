using backend_pairing_interview_project.catalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Http.Results;
using Xunit;

namespace backend_pairing_interview_project.Tests.Catalog
{
    public class ItemsControllerTest
    {
        private ItemsController _itemsController;
        private Mock<ItemsService> _mockItemsService;

        public ItemsControllerTest()
        {
            _mockItemsService = new Mock<ItemsService>(null, null);
            _itemsController = new ItemsController(_mockItemsService.Object);
        }

        [Fact]
        public void GetItems_ShouldReturn200Ok()
        {
            var sampleList = new List<LineDto> { new LineDto() };
            _mockItemsService.Setup(s => s.GetAllAvailableItems()).Returns(sampleList);

            var result = _itemsController.GetItems();
            var okResult = result as OkNegotiatedContentResult<List<LineDto>>;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(sampleList, okResult.Content);
            _mockItemsService.Verify(s => s.GetAllAvailableItems(), Times.Once);
        }
    }
}
