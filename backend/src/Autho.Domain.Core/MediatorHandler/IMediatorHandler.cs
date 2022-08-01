using Autho.Domain.Core.Notifications;

namespace Autho.Domain.Core.MediatorHandler
{
    public interface IMediatorHandler
    {
        Task RaiseNotification<T>(T notification) where T : DomainNotification;
    }
}
