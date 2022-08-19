using Autho.Framework.Domain.Messaging.Requests.Interfaces;

namespace Autho.Framework.Domain.Messaging.Bus.Interfaces
{
    public interface IBus
    {
        Task Command<TCommand>(TCommand command, CancellationToken cancellationToken = default) 
            where TCommand : ICommand;
        
        Task Event<TEvent>(TEvent @event, CancellationToken cancellationToken = default) 
            where TEvent : IEvent;
        
        Task Notification<TNotification>(TNotification notification, CancellationToken cancellationToken = default) 
            where TNotification : INotification;
        
        Task<TResult> Query<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default) 
            where TQuery : IQuery<TResult> 
            where TResult : IQueryResult;
    }
}
