using backend_pairing_interview_project.offers;
using backend_pairing_interview_project.utils;

namespace backend_pairing_interview_project.Tests.Offers
{
    public static class OfferFixture
    {
        public static Offer GetOfferOne()
        {
            return new Offer
            {
                Id = "offerOne",
                Description = "offerOneDescription",
                Name = "offerName",
                ItemId = "offerOneItemId",
                PriceReduction = new Money(1.0m),
                QuantityThreshold = 5
            };
        }

        public static Offer GetOfferTwo()
        {
            return new Offer
            {
                Id = "offerTwo",
                Description = "offerTwoDescription",
                Name = "offerTwoName",
                ItemId = "offerTwoItemId",
                PriceReduction = new Money(2.0m),
                QuantityThreshold = 2
            };
        }
    }
}
