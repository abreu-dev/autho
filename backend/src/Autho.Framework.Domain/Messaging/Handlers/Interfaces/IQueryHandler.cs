using Autho.Framework.Domain.Messaging.Requests.Interfaces;

namespace Autho.Framework.Domain.Messaging.Handlers.Interfaces
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult> where TResult : IQueryResult
    {
        Task<TResult> Handle(TQuery query, CancellationToken cancellationToken = default);
    }
}
