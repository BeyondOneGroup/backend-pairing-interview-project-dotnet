using backend_pairing_interview_project.Orders;
using backend_pairing_interview_project.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_pairing_interview_project.Tests.Orders
{
    public static class OrderFixture
    {
        public static Order GetOrderOne()
        {
            var orderItem = new OrderItem
            {
                Id = "OrderItemOne",
                Name = "ItemOne",
                OriginalPrice = new Money(15.0m),
                DiscountedPrice = new Money(10.0m)
            };

            var orderOffer = new OrderOffer
            {
                Id = "OrderOfferOne",
                Name = "OfferOne",
                ItemId = "Juice",
                PriceReduction = new Money(5.0m),
                QuantityThreshold = 2
            };

            return new Order
            {
                Id = "OrderOne",
                Items = new List<OrderItem> { orderItem },
                Offers = new List<OrderOffer> { orderOffer }
            };
        }
    }
}
