using System.Collections.Generic;
using System.Linq;

namespace backend_pairing_interview_project.Orders
{
    public class Order
    {
        public string Id { get; set; }
        public List<OrderItem> Items { get; set; }
        public List<OrderOffer> Offers { get; set; }

        // Factory method to convert from DTO
        public static Order From(OrderDto orderDto)
        {
            var orderItems = orderDto.Items?
                .Select(OrderItem.From)
                .ToList() ?? new List<OrderItem>();

            var orderOffers = orderDto.Offers?
                .Select(OrderOffer.From)
                .ToList() ?? new List<OrderOffer>();

            var order = new Order
            {
                Id = orderDto.Id,
                Items = orderItems,
                Offers = orderOffers
            };

            return new Order
            {
                Id = orderDto.Id,
                Items = orderItems,
                Offers = orderOffers
            };
        }

        // Method to convert back to DTO
        public OrderDto ToOrderDto()
        {
            var orderDto = new OrderDto
            {
                Id = this.Id,
                Items = this.Items?.Select(i => i.ToOrderItemDto()).ToList(),
                Offers = this.Offers?.Select(o => o.ToOrderOfferDto()).ToList()
            };

            return orderDto;
        }
    }
}