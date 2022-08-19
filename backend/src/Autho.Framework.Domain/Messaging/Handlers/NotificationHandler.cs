using Autho.Framework.Domain.Messaging.Handlers.Interfaces;
using Autho.Framework.Domain.Messaging.Requests.Interfaces;

namespace Autho.Framework.Domain.Messaging.Handlers
{
    public class NotificationHandler : INotificationHandler
    {
        private readonly ICollection<INotification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<INotification>();
        }

        public bool HasNotifications => _notifications.Any();

        public IEnumerable<INotification> GetNotifications()
        {
            return _notifications;
        }

        public Task Handle(INotification notification, CancellationToken cancellationToken = default)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }
    }
}
