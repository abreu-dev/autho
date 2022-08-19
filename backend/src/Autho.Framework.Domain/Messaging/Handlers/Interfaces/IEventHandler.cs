using Autho.Framework.Domain.Messaging.Requests.Interfaces;

namespace Autho.Framework.Domain.Messaging.Handlers.Interfaces
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task Handle(TEvent @event, CancellationToken cancellationToken = default);
    }
}
