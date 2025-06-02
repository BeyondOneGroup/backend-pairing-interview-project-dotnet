namespace backend_pairing_interview_project.Orders
{
    using System.Collections.Generic;

    public class OrderDto
    {
        public string Id { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public List<OrderOfferDto> Offers { get; set; }
    }
}