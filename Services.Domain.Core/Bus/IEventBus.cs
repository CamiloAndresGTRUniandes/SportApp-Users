namespace Services.Domain.Core.Bus ;
using Commands;
using Events;

    public interface IEventBus
    {
        Task<bool> Publish<T>(T even) where T : Event;
        Task SendCommand<T>(T command) where T : Command;

        void Subscribe<T, TH>(string queue)
            where T : Event
            where TH : IEventHandler<T>;
    }
