using backend_pairing_interview_project.utils;
using log4net;

namespace backend_pairing_interview_project.Utils
{
    public class ApplicationEventPublisher : IApplicationEventPublisher
    {
        private readonly ILog _logger;

        public ApplicationEventPublisher()
        {
            _logger = LogManager.GetLogger(typeof(ApplicationEventPublisher));
        }

        void IApplicationEventPublisher.OnEvent(Event @event)
        {
            _logger.InfoFormat("Event received: {0}", @event.Name);
        }

        void IApplicationEventPublisher.PublishEvent(Event @event)
        {
            _logger.InfoFormat("Publishing event: {0}", @event.Name);
        }
    }
}