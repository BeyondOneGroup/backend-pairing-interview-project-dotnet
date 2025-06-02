using backend_pairing_interview_project.catalog;
using backend_pairing_interview_project.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Xunit;

namespace backend_pairing_interview_project.Tests.Catalog
{
    public class ItemStoreTests
    {
        private ItemStore _itemStore;
        private Dictionary<string, Item> _items;

        public ItemStoreTests()
        {
            _items = new Dictionary<string, Item>
            {
                { ItemFixture.GetItemOne().Id, ItemFixture.GetItemOne() },
                { ItemFixture.GetItemTwo().Id, ItemFixture.GetItemTwo() }
            };

            _itemStore = new ItemStore(_items);
        }

        [Fact]
        public void Get_ShouldReturnItem_WhenIdExists()
        {
            var expectedItem = ItemFixture.GetItemOne();

            var item = _itemStore.Get(expectedItem.Id);

            Assert.IsNotNull(item);
            Assert.AreEqual(expectedItem.Id, item.Id);
            Assert.AreEqual(expectedItem.Name, item.Name);
            Assert.AreEqual(expectedItem.Description, item.Description);
            Assert.AreEqual(expectedItem.Price.Value, item.Price.Value);
        }

        [Fact]
        public void Get_ShouldThrowException_WhenIdDoesNotExist()
        {
            Assert.ThrowsException<ItemNotFoundException>(() =>
                _itemStore.Get("fakeItemId"));
        }

        [Fact]
        public void GetAllItems_ShouldReturnAllItems()
        {
            var itemList = _itemStore.GetAllItems();
            Assert.AreEqual(2, itemList.Count);
        }

        [Fact]
        public void Add_ShouldAddItem()
        {
            var newItem = new Item
            {
                Id = "newItemId",
                Name = "newName",
                Description = "newDescription",
                Price = new Money(5.2m),
                Cost = new Money(2.3m)
            };

            _itemStore.Add(newItem);

            Assert.IsTrue(_items.ContainsKey("newItemId"));
            var storedItem = _items["newItemId"];

            Assert.AreEqual("newName", storedItem.Name);
            Assert.AreEqual("newDescription", storedItem.Description);
            Assert.AreEqual(5.2m, storedItem.Price.Value);
            Assert.AreEqual(2.3m, storedItem.Cost.Value);
        }

        [Fact]
        public void Delete_ShouldRemoveItem()
        {
            var itemId = ItemFixture.GetItemOne().Id;

            _itemStore.Delete(itemId);

            Assert.IsFalse(_items.ContainsKey(itemId));
        }
    }
}
