using System.Collections.Generic;
using System.Web.Http;

namespace backend_pairing_interview_project.catalog
{
    [RoutePrefix("items")]
    public class ItemsController : ApiController
    {
        private readonly ItemsService _itemsService;

        public ItemsController(ItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        // GET /items
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetItems()
        {
            List<LineDto> availableItems = _itemsService.GetAllAvailableItems();
            return Ok(availableItems);
        }
    }
}