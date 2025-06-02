using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace backend_pairing_interview_project.catalog
{
    [RoutePrefix("items-management")]
    public class ItemsManagementController : ApiController
    {
        private readonly ItemsService _itemsService;

        public ItemsManagementController(ItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetInventory()
        {
            var items = _itemsService.GetAllItems();
            return Ok(items);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Upsert([FromBody] List<ItemsManagementLineDto> itemsDto)
        {
            if (itemsDto == null)
                return BadRequest("Invalid payload.");

            foreach (var line in itemsDto)
            {
                _itemsService.AddItem(line.Item, line.Quantity);
            }

            return Ok(itemsDto);
        }

        [HttpDelete]
        [Route("")]
        public IHttpActionResult DeleteItems([FromBody] ItemIdsDto itemIdsDto)
        {
            if (itemIdsDto == null || itemIdsDto.Ids == null)
                return BadRequest("Invalid item ID list.");

            _itemsService.Delete(itemIdsDto);
            return Ok(itemIdsDto);
        }
    }
}