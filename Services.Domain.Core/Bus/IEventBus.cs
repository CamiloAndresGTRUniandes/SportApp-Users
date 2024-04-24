namespace Services.Domain.Core.Bus ;
using Events;

    public interface IEventBus
    {
        Task<bool> Publish<T>(T even) where T : Event;
    }
