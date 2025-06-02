using System.Collections.Generic;
using System.Web.Http;

namespace backend_pairing_interview_project.offers
{
    [RoutePrefix("offers")]
    public class OfferController : ApiController
    {
        private readonly OfferStore _offerStore;

        public OfferController(OfferStore offerStore)
        {
            _offerStore = offerStore;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetOffers()
        {
            List<OfferDto> offers = _offerStore.GetAllOffers();
            return Ok(offers);
        }
    }
}