using System;
using System.Collections.Generic;

namespace backend_pairing_interview_project.Orders
{
    public class OrderStore
    {
        private readonly Dictionary<string, Order> _store;

        public OrderStore(Dictionary<string, Order> store)
        {
            _store = store ?? new Dictionary<string, Order>();
        }

        public Order GetOrder(string orderId)
        {
            if (!_store.ContainsKey(orderId))
            {
                throw new OrderNotFoundException("Unable to find order against id: {0}", orderId);
            }

            return _store[orderId];
        }

        public void SaveOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            _store[order.Id] = order;
        }
    }
}