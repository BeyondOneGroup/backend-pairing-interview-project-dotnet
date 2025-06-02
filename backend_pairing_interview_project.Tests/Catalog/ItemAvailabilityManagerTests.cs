using backend_pairing_interview_project.catalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Xunit;

namespace backend_pairing_interview_project.Tests.Catalog
{
    public class ItemAvailabilityManagerTests
    {
        private ItemAvailabilityManager _itemAvailabilityManager;
        private Dictionary<string, int> _itemAvailability;

        public ItemAvailabilityManagerTests()
        {
            _itemAvailability = new Dictionary<string, int>
                {
                    { ItemFixture.GetItemOne().Id, 10 },
                };

            _itemAvailabilityManager = new ItemAvailabilityManager(_itemAvailability);
        }

        [Fact]
        public void GetAvailableItems_ShouldReturnOnlyAvailable()
        {
            var result = _itemAvailabilityManager.GetAvailableItemQuantities();
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [Fact]
        public void GetAllItems_ShouldReturnAllItems()
        {
            var result = _itemAvailabilityManager.GetAllItemQuantities();
            Assert.Equals(2, result.Count);
        }

        [Fact]
        public void SetItemQuantity_ShouldAddNewItem()
        {
            _itemAvailabilityManager.SetItemQuantity("newItem", 10);

            Assert.IsTrue(_itemAvailability.ContainsKey("newItem"));
            Assert.Equals(10, _itemAvailability["newItem"]);
        }

        [Fact]
        public void Delete_ShouldRemoveItem()
        {
            var itemId = ItemFixture.GetItemOne().Id;
            _itemAvailabilityManager.Delete(itemId);

            Assert.IsFalse(_itemAvailability.ContainsKey(itemId));
        }

        [Fact]
        public void DecrementQuantity_ShouldReduceByOne()
        {
            var itemId = ItemFixture.GetItemOne().Id;

            _itemAvailabilityManager.DecrementQuantity(itemId);

            Assert.Equals(9, _itemAvailability[itemId]);
        }

        [Fact]
        public void DecrementQuantity_ShouldThrow_WhenItemDoesNotExist()
        {
            Assert.ThrowsException<ItemNotFoundException>(() =>
                _itemAvailabilityManager.DecrementQuantity("non-existent"));
        }
    }
}
