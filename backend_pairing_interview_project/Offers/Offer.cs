using backend_pairing_interview_project.utils;

namespace backend_pairing_interview_project.offers
{
    public class Offer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ItemId { get; set; }
        public Money PriceReduction { get; set; }
        public int? QuantityThreshold { get; set; }

        public static Offer From(OffersManagementOfferDto dto)
        {
            return new Offer
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                ItemId = dto.ItemId,
                QuantityThreshold = dto.QuantityThreshold,
                PriceReduction = new Money(dto.PriceReduction)
            };
        }

        public OfferDto ToOfferDto()
        {
            return new OfferDto
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                ItemId = this.ItemId,
                QuantityThreshold = this.QuantityThreshold,
                PriceReduction = this.PriceReduction.Value
            };
        }

        public OffersManagementOfferDto ToOffersManagementOfferDto()
        {
            return new OffersManagementOfferDto
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                ItemId = this.ItemId,
                QuantityThreshold = this.QuantityThreshold,
                PriceReduction = this.PriceReduction.Value
            };
        }
    }
}