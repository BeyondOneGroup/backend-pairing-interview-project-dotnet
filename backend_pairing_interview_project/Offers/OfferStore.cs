using System.Collections.Generic;
using System.Linq;

namespace backend_pairing_interview_project.offers
{
    public class OfferStore
    {
        private readonly IDictionary<string, Offer> _offers;

        public OfferStore(IDictionary<string, Offer> offers)
        {
            _offers = offers ?? new Dictionary<string, Offer>();
        }

        public List<OfferDto> GetAllOffers()
        {
            return _offers.Values
                          .Select(offer => offer.ToOfferDto())
                          .ToList();
        }

        public List<OffersManagementOfferDto> GetAllManagementOffers()
        {
            return _offers.Values
                          .Select(offer => offer.ToOffersManagementOfferDto())
                          .ToList();
        }

        public void AddOffer(OffersManagementOfferDto dto)
        {
            var offer = Offer.From(dto);
            _offers[offer.Id] = offer;
        }

        public void AddOffers(IEnumerable<OffersManagementOfferDto> dtos)
        {
            foreach (var dto in dtos)
            {
                AddOffer(dto);
            }
        }

        public void Delete(string offerId)
        {
            _offers.Remove(offerId);
        }
    }
}