using log4net;

namespace backend_pairing_interview_project.utils
{
    public class EventPublisher
    {
        private readonly IApplicationEventPublisher _publisher;
        private readonly ILog _logger;

        public EventPublisher(IApplicationEventPublisher publisher)
        {
            _publisher = publisher;
            _logger = LogManager.GetLogger(typeof(EventPublisher));
        }

        public void PublishEvent(Event @event)
        {
            _logger.Info($"Publishing {@event.Name} event: [{@event}]");
            _publisher.PublishEvent(@event);
        }
    }
}
