using backend_pairing_interview_project.utils;

namespace backend_pairing_interview_project.Orders
{
    public class OrderOffer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ItemId { get; set; }
        public Money PriceReduction { get; set; }
        public int? QuantityThreshold { get; set; }

        public static OrderOffer From(OrderOfferDto offer)
        {
            return new OrderOffer
            {
                Id = offer.Id,
                Name = offer.Name,
                ItemId = offer.ItemId,
                QuantityThreshold = offer.QuantityThreshold,
                PriceReduction = new Money(offer.PriceReduction)
            };
        }

        public OrderOfferDto ToOrderOfferDto()
        {
            return new OrderOfferDto
            {
                Id = this.Id,
                Name = this.Name,
                ItemId = this.ItemId,
                PriceReduction = this.PriceReduction.Value,
                QuantityThreshold = this.QuantityThreshold
            };
        }
    }
}