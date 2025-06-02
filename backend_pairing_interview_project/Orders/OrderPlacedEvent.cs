using backend_pairing_interview_project.utils;

namespace backend_pairing_interview_project.Orders
{
    public class OrderPlacedEvent : Event
    {
        public Order Order { get; set; }

        public OrderPlacedEvent() { }

        public OrderPlacedEvent(string name, Order order)
        {
            Name = name;
            Order = order;
            Data = order;
        }
    }
}