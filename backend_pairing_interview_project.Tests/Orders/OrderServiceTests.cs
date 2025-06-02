using backend_pairing_interview_project.Orders;
using backend_pairing_interview_project.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace backend_pairing_interview_project.Tests.Orders
{
    public class OrderServiceTests
    {
        private readonly Mock<OrderStore> _mockOrderStore;
        private readonly Mock<EventPublisher> _mockEventPublisher;
        private readonly OrderService _orderService;

        public OrderServiceTests()
        {
            _mockOrderStore = new Mock<OrderStore>();
            _mockEventPublisher = new Mock<EventPublisher>();
            _orderService = new OrderService(_mockOrderStore.Object);
        }

        [Fact]
        public void PlaceOrder_ShouldSaveOrderAndPublishEvent()
        {
            var orderDto = OrderFixture.GetOrderOne().ToOrderDto();

            _orderService.PlaceOrder(orderDto);

            _mockEventPublisher.Verify(e => e.PublishEvent(It.IsAny<OrderPlacedEvent>()), Times.Once);
            _mockOrderStore.Verify(s => s.SaveOrder(It.IsAny<Order>()), Times.Once);
        }

        [Fact]
        public void GetOrder_ShouldReturnDto_WhenOrderExists()
        {
            var order = OrderFixture.GetOrderOne();
            _mockOrderStore.Setup(s => s.GetOrder(order.Id)).Returns(order);

            var result = _orderService.GetOrder(order.Id);

            Assert.IsNotNull(result);
            _mockOrderStore.Verify(s => s.GetOrder(order.Id), Times.Once);

            for (int i = 0; i < result.Items.Count; i++)
            {
                AssertOrderItemEqual(order.Items[i], result.Items[i]);
            }

            for (int i = 0; i < result.Offers.Count; i++)
            {
                AssertOrderOfferEqual(order.Offers[i], result.Offers[i]);
            }
        }

        [Fact]
        public void GetOrder_ShouldReturnNull_WhenOrderNotFound()
        {
            var orderId = "does-not-exist";
            _mockOrderStore.Setup(s => s.GetOrder(It.IsAny<string>())).Throws<OrderNotFoundException>();

            var result = _orderService.GetOrder(orderId);

            Assert.IsNull(result);
            _mockOrderStore.Verify(s => s.GetOrder(orderId), Times.Once);
        }

        private void AssertOrderItemEqual(OrderItem expected, OrderItemDto actual)
        {
            Assert.Equals(expected.Id, actual.Id);
            Assert.Equals(expected.Name, actual.Name);
            Assert.Equals(expected.OriginalPrice.Value, actual.OriginalPrice);
            Assert.Equals(expected.DiscountedPrice.Value, actual.DiscountedPrice);
        }

        private void AssertOrderOfferEqual(OrderOffer expected, OrderOfferDto actual)
        {
            Assert.Equals(expected.Id, actual.Id);
            Assert.Equals(expected.Name, actual.Name);
            Assert.Equals(expected.ItemId, actual.ItemId);
            Assert.Equals(expected.PriceReduction.Value, actual.PriceReduction);
            Assert.Equals(expected.QuantityThreshold, actual.QuantityThreshold);
        }
    }
}
