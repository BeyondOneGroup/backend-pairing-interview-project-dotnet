using System.Collections.Generic;
using System.Web.Http;

namespace backend_pairing_interview_project.offers
{
    [RoutePrefix("offers-management")]
    public class OfferManagementController : ApiController
    {
        private readonly OfferStore _offerStore;

        public OfferManagementController(OfferStore offerStore)
        {
            _offerStore = offerStore;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetOffers()
        {
            var allOffers = _offerStore.GetAllManagementOffers();
            return Ok(allOffers);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Upsert([FromBody] List<OffersManagementOfferDto> offersManagementOfferDtos)
        {
            if (offersManagementOfferDtos == null || offersManagementOfferDtos.Count == 0)
                return BadRequest("Request body is empty");

            foreach (var offer in offersManagementOfferDtos)
            {
                _offerStore.AddOffer(offer);
            }

            return Ok(offersManagementOfferDtos);
        }

        [HttpDelete]
        [Route("")]
        public IHttpActionResult Delete([FromBody] OfferIdsDto offerIdsDto)
        {
            if (offerIdsDto == null || offerIdsDto.Ids == null || offerIdsDto.Ids.Count == 0)
                return BadRequest("Missing IDs to delete");

            foreach (var id in offerIdsDto.Ids)
            {
                _offerStore.Delete(id);
            }

            return Ok(offerIdsDto);
        }
    }
}