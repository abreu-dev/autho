using Autho.Framework.Domain.Messaging.Requests.Interfaces;

namespace Autho.Framework.Domain.Messaging.Handlers.Interfaces
{
    public interface INotificationHandler
    {
        bool HasNotifications { get; }
        IEnumerable<INotification> GetNotifications();

        Task Handle(INotification notification, CancellationToken cancellationToken = default);
    }
}
