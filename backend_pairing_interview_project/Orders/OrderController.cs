using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace backend_pairing_interview_project.Orders
{
    [RoutePrefix("orders")]
    public class OrderController : ApiController
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetOrders([FromUri] List<string> orderIds)
        {
            if (orderIds == null || !orderIds.Any())
                return BadRequest("Missing orderIds[] in query string.");

            var result = orderIds
                .Select(id => _orderService.GetOrder(id))
                .Where(order => order != null)
                .ToList();

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult PlaceOrders([FromBody] List<OrderDto> orderDtos)
        {
            if (orderDtos == null || !orderDtos.Any())
                return BadRequest("Missing or invalid orderDtos.");

            foreach (var dto in orderDtos)
            {
                _orderService.PlaceOrder(dto);
            }

            return Ok(orderDtos);
        }
    }
}