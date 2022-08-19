using Autho.Framework.Domain.Messaging.Requests.Interfaces;

namespace Autho.Framework.Domain.Messaging.Dispatchers.Interfaces
{
    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default) 
            where TQuery : IQuery<TResult>
            where TResult : IQueryResult;
    }
}
