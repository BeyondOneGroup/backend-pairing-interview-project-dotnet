namespace backend_pairing_interview_project.utils
{
    public interface IApplicationEventPublisher
    {
        void OnEvent(Event @event);
        void PublishEvent(Event @event);
    }
}
