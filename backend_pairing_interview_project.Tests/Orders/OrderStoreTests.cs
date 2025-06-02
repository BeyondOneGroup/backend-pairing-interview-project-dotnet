using backend_pairing_interview_project.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Xunit;

namespace backend_pairing_interview_project.Tests.Orders
{
    public class OrderStoreTests
    {
        private OrderStore _orderStore;
        private Dictionary<string, Order> _orders;

        public OrderStoreTests()
        {
            var order = OrderFixture.GetOrderOne();
            _orders = new Dictionary<string, Order>
            {
                [order.Id] = order
            };

            _orderStore = new OrderStore(_orders);
        }

        [Fact]
        public void GetOrder_ShouldReturnOrder_WhenIdExists()
        {
            var expectedOrder = OrderFixture.GetOrderOne();

            var actualOrder = _orderStore.GetOrder(expectedOrder.Id);

            Assert.IsNotNull(actualOrder);
            Assert.Equals(expectedOrder.Id, actualOrder.Id);

            for (int i = 0; i < actualOrder.Items.Count; i++)
            {
                AssertOrderItemEqual(expectedOrder.Items[i], actualOrder.Items[i]);
            }

            for (int i = 0; i < actualOrder.Offers.Count; i++)
            {
                AssertOrderOfferEqual(expectedOrder.Offers[i], actualOrder.Offers[i]);
            }
        }

        [Fact]
        public void GetOrder_ShouldThrow_WhenIdNotExists()
        {
            Assert.ThrowsException<OrderNotFoundException>(() => _orderStore.GetOrder("fakeOrderId"));
        }

        [Fact]
        public void SaveOrder_ShouldAddOrUpdateOrder()
        {
            var order = OrderFixture.GetOrderOne();

            _orderStore.SaveOrder(order);

            Assert.IsTrue(_orders.ContainsKey(order.Id));

            var savedOrder = _orders[order.Id];

            for (int i = 0; i < savedOrder.Items.Count; i++)
            {
                AssertOrderItemEqual(order.Items[i], savedOrder.Items[i]);
            }

            for (int i = 0; i < savedOrder.Offers.Count; i++)
            {
                AssertOrderOfferEqual(order.Offers[i], savedOrder.Offers[i]);
            }
        }

        private void AssertOrderItemEqual(OrderItem expected, OrderItem actual)
        {
            Assert.Equals(expected.Id, actual.Id);
            Assert.Equals(expected.Name, actual.Name);
            Assert.Equals(expected.OriginalPrice.Value, actual.OriginalPrice.Value);
            Assert.Equals(expected.DiscountedPrice.Value, actual.DiscountedPrice.Value);
        }

        private void AssertOrderOfferEqual(OrderOffer expected, OrderOffer actual)
        {
            Assert.Equals(expected.Id, actual.Id);
            Assert.Equals(expected.Name, actual.Name);
            Assert.Equals(expected.ItemId, actual.ItemId);
            Assert.Equals(expected.PriceReduction.Value, actual.PriceReduction.Value);
            Assert.Equals(expected.QuantityThreshold, actual.QuantityThreshold);
        }
    }
}
