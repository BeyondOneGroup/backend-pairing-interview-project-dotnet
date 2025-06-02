namespace backend_pairing_interview_project.utils
{
    public class Event
    {
        public string Name { get; set; }
        public object Data { get; set; }

        public Event() { }

        public Event(string name, object data)
        {
            Name = name;
            Data = data;
        }
    }
}