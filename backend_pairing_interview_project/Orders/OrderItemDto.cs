namespace backend_pairing_interview_project.Orders
{
    public class OrderItemDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
    }
}