namespace Services.Domain.Core.Commands ;
using Events;

    public abstract class Command : Message
    {
        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; protected set; }
        public string Queue { get; set; }
    }
