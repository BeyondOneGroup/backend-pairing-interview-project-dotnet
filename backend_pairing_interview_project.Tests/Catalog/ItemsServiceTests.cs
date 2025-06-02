using backend_pairing_interview_project.catalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace backend_pairing_interview_project.Tests.Catalog
{
    public class ItemsServiceTests
    {
        private readonly Mock<ItemAvailabilityManager> _mockAvailabilityManager;
        private readonly Mock<ItemStore> _mockItemStore;
        private readonly ItemsService _itemsService;

        public ItemsServiceTests()
        {
            _mockItemStore = new Mock<ItemStore>(new Dictionary<string, Item>());
            _mockAvailabilityManager = new Mock<ItemAvailabilityManager>(new Dictionary<string, int>());
            _itemsService = new ItemsService(_mockItemStore.Object, _mockAvailabilityManager.Object);
        }

        [Fact]
        public void GetAllAvailableItems_ShouldReturn1Item_WhenItemExists()
        {
            var quantityMap = new Dictionary<string, int> { ["item1"] = 10 };
            var item = ItemFixture.GetItemOne();

            _mockAvailabilityManager.Setup(x => x.GetAvailableItemQuantities()).Returns(quantityMap);
            _mockItemStore.Setup(x => x.Get("item1")).Returns(item);

            var result = _itemsService.GetAllAvailableItems();

            Assert.Equals(1, result.Count);
        }

        [Fact]
        public void GetAllAvailableItems_ShouldReturnEmpty_WhenItemMissing()
        {
            var quantityMap = new Dictionary<string, int> { ["item1"] = 10 };

            _mockAvailabilityManager.Setup(x => x.GetAvailableItemQuantities()).Returns(quantityMap);
            _mockItemStore.Setup(x => x.Get(It.IsAny<string>())).Throws<ItemNotFoundException>();

            var result = _itemsService.GetAllAvailableItems();

            Assert.Equals(result.Count, 0);
        }

        [Fact]
        public void GetAllItems_ShouldReturnAll()
        {
            var quantityMap = new Dictionary<string, int>
            {
                ["item1"] = 10,
                ["item2"] = 0
            };

            _mockAvailabilityManager.Setup(x => x.GetAllItemQuantities()).Returns(quantityMap);
            _mockItemStore.Setup(x => x.Get("item1")).Returns(ItemFixture.GetItemOne());
            _mockItemStore.Setup(x => x.Get("item2")).Returns(ItemFixture.GetItemTwo());

            var result = _itemsService.GetAllItems();

            Assert.Equals(2, result.Count);
        }

        [Fact]
        public void GetAllItems_ShouldReturnEmpty_WhenItemsMissing()
        {
            var quantityMap = new Dictionary<string, int>
            {
                ["item1"] = 10,
                ["item2"] = 0
            };

            _mockAvailabilityManager.Setup(x => x.GetAllItemQuantities()).Returns(quantityMap);
            _mockItemStore.Setup(x => x.Get(It.IsAny<string>())).Throws<ItemNotFoundException>();

            var result = _itemsService.GetAllItems();
            // Assert
            Assert.Equals(0, result.Count);
        }

        [Fact]
        public void AddItem_ShouldCallStoreAndAvailability()
        {
            var dto = ItemFixture.GetItemManagementItemDto();
            var quantity = 10;

            _itemsService.AddItem(dto, quantity);

            _mockItemStore.Verify(x => x.Add(It.IsAny<Item>()), Times.Once);
            _mockAvailabilityManager.Verify(x => x.SetItemQuantity(dto.Id, quantity), Times.Once);
        }

        [Fact]
        public void Delete_ShouldRemoveFromStoreAndAvailability()
        {
            var dto = new ItemIdsDto();
            dto.Ids.Add("item1");

            _itemsService.Delete(dto);

            _mockItemStore.Verify(x => x.Delete("item1"), Times.Once);
            _mockAvailabilityManager.Verify(x => x.Delete("item1"), Times.Once);
        }
    }
}
