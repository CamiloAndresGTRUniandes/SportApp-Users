namespace MicroRabbit.Domain.Core.Events
{
    public abstract class Event
    {
        public DateTime Timestamp { get; protected set; }

        public string Queue { get; protected set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
