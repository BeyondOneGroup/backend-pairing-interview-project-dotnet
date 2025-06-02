using backend_pairing_interview_project.catalog;
using backend_pairing_interview_project.Orders;
using backend_pairing_interview_project.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Xunit;

namespace backend_pairing_interview_project.Tests
{
    public class SlowTest
    {
        private readonly ItemsManagementController _itemsManagementController;
        private readonly OrderController _orderController;

        public SlowTest()
        {
            // Setup your controllers with in-memory services or DI-mocked services
            var itemStore = new ItemStore(new Dictionary<string, Item>()); // your mock storage
            var orderStore = new OrderStore(new Dictionary<string, Order>());
            var quantityMap = new Dictionary<string, int>();
            var availabilityManager = new ItemAvailabilityManager(quantityMap);
            var itemsService = new ItemsService(itemStore, availabilityManager);
            var orderService = new OrderService(orderStore); // assumes correct implementation

            _itemsManagementController = new ItemsManagementController(itemsService);
            _orderController = new OrderController(orderService);
        }

        [Fact]
        public void ItemQuantityShouldBeDecrementedIfOrderIsPlaced()
        {
            // 1. Add item to catalog
            var itemDto = ItemFixture.GetItem();
            var lineDto = new ItemsManagementLineDto
            {
                Item = itemDto,
                Quantity = 2
            };
            var dtoList = new List<ItemsManagementLineDto> { lineDto };
            _itemsManagementController.Upsert(dtoList);

            // 2. Place an order
            var orderDto = OrderFixture.GetOrderOne().ToOrderDto();
            orderDto.Items.ForEach(i => i.Id = itemDto.Id);
            _orderController.PlaceOrders(new List<OrderDto> { orderDto });

            // 3. Check inventory
            var response = _itemsManagementController.GetInventory();
            var contentResult = response as OkNegotiatedContentResult<List<ItemsManagementLineDto>>;

            // Ensure the response was OK and contains content
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);

            // Find the updated item by ID
            var updatedItem = contentResult.Content
                .FirstOrDefault(l => l.Item.Id == itemDto.Id);

            // Assert item was found and quantity is correct
            Assert.IsNotNull(updatedItem);
            Assert.Equals(1, updatedItem.Quantity);
        }
    }

    public static class ItemFixture
    {
        public static ItemsManagementItemDto GetItem()
        {
            return new ItemsManagementItemDto
            {
                Id = "item-1",
                Name = "Test Item",
                Description = "For test",
                Price = 10,
                Cost = 5
            };
        }
    }

    public static class OrderFixture
    {
        public static Order GetOrderOne()
        {
            return new Order
            {
                Id = "order-1",
                Items = new List<OrderItem>
            {
                new OrderItem { Id = "", Name = "Placeholder", DiscountedPrice = new Money(8), OriginalPrice = new Money(10) }
            }
            };
        }
    }
}
