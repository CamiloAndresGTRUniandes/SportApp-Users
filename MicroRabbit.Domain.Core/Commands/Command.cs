namespace MicroRabbit.Domain.Core.Commands ;
using Events;

    public abstract class Command : Message
    {
        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; protected set; }
    }
