namespace backend_pairing_interview_project.Orders
{
    public class OrderOfferDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ItemId { get; set; }
        public decimal PriceReduction { get; set; }
        public int? QuantityThreshold { get; set; }
    }
}