using backend_pairing_interview_project.offers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Xunit;

namespace backend_pairing_interview_project.Tests.Offers
{
    public class OfferStoreTests
    {
        private OfferStore _offerStore;
        private Dictionary<string, Offer> _offers;

        public OfferStoreTests()
        {
            _offers = new Dictionary<string, Offer>();
            var offerOne = OfferFixture.GetOfferOne();
            _offers[offerOne.Id] = offerOne;

            _offerStore = new OfferStore(_offers);
        }

        [Fact]
        public void GetAllOffers_ReturnsLoadedOffers()
        {
            var allOffers = _offerStore.GetAllOffers();

            Assert.IsNotNull(allOffers);
            foreach (var offerDto in allOffers)
            {
                var expected = _offers[offerDto.Id];

                Assert.Equals(expected.Id, offerDto.Id);
                Assert.Equals(expected.Name, offerDto.Name);
                Assert.Equals(expected.Description, offerDto.Description);
                Assert.Equals(expected.ItemId, offerDto.ItemId);
                Assert.Equals(expected.QuantityThreshold, offerDto.QuantityThreshold);
                Assert.Equals(expected.PriceReduction.Value, offerDto.PriceReduction);
            }
        }

        [Fact]
        public void GetAllManagementOffers_ReturnsCorrectDtos()
        {
            var allOffers = _offerStore.GetAllManagementOffers();

            Assert.IsNotNull(allOffers);
            foreach (var offerDto in allOffers)
            {
                var expected = _offers[offerDto.Id];

                Assert.Equals(expected.Id, offerDto.Id);
                Assert.Equals(expected.Name, offerDto.Name);
                Assert.Equals(expected.Description, offerDto.Description);
                Assert.Equals(expected.ItemId, offerDto.ItemId);
                Assert.Equals(expected.QuantityThreshold, offerDto.QuantityThreshold);
                Assert.Equals(expected.PriceReduction.Value, offerDto.PriceReduction);
            }
        }

        [Fact]
        public void AddOffers_AddsOfferToStore()
        {
            var newOffer = OfferFixture.GetOfferTwo();
            _offerStore.AddOffers((IEnumerable<OffersManagementOfferDto>)newOffer.ToOffersManagementOfferDto());

            Assert.Equals(2, _offers.Count);
            var added = _offers[newOffer.Id];

            Assert.Equals(newOffer.Id, added.Id);
            Assert.Equals(newOffer.Name, added.Name);
            Assert.Equals(newOffer.Description, added.Description);
            Assert.Equals(newOffer.ItemId, added.ItemId);
            Assert.Equals(newOffer.QuantityThreshold, added.QuantityThreshold);
            Assert.Equals(newOffer.PriceReduction.Value, added.PriceReduction.Value);
        }

        [Fact]
        public void DeleteOffer_RemovesEntry()
        {
            var offer = OfferFixture.GetOfferOne();
            _offerStore.Delete(offer.Id);

            Assert.IsFalse(_offers.ContainsKey(offer.Id));
        }
    }
}
