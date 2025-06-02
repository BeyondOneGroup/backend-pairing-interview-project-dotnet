using backend_pairing_interview_project.utils;

namespace backend_pairing_interview_project.Orders
{
    public class OrderItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Money OriginalPrice { get; set; }
        public Money DiscountedPrice { get; set; }

        public static OrderItem From(OrderItemDto item)
        {
            return new OrderItem
            {
                Id = item.Id,
                Name = item.Name,
                OriginalPrice = new Money(item.OriginalPrice),
                DiscountedPrice = new Money(item.DiscountedPrice)
            };
        }

        public OrderItemDto ToOrderItemDto()
        {
            return new OrderItemDto
            {
                Id = this.Id,
                Name = this.Name,
                OriginalPrice = this.OriginalPrice.Value,
                DiscountedPrice = this.DiscountedPrice.Value
            };
        }
    }
}