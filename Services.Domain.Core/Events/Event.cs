namespace Services.Domain.Core.Events ;

    public abstract class Event
    {
        protected Event()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; protected set; }

        public string Queue { get; protected set; }
    }
