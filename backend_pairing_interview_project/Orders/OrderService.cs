namespace backend_pairing_interview_project.Orders
{
    public class OrderService
    {
        private const string ORDER_PLACED_EVENT_NAME = "ORDER_PLACED";

        private readonly OrderStore _orderStore;

        public OrderService(OrderStore orderStore)
        {
            _orderStore = orderStore;
        }

        public void PlaceOrder(OrderDto orderDto)
        {
            var order = Order.From(orderDto);
            _orderStore.SaveOrder(order);
        }

        public OrderDto GetOrder(string orderId)
        {
            try
            {
                var order = _orderStore.GetOrder(orderId);
                return order.ToOrderDto();
            }
            catch (OrderNotFoundException)
            {
                return null;
            }
        }
    }
}