using Autho.Framework.Domain.Messaging.Dispatchers.Interfaces;
using Autho.Framework.Domain.Messaging.Handlers.Interfaces;
using Autho.Framework.Domain.Messaging.Requests.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Autho.Framework.Domain.Messaging.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default) 
            where TQuery : IQuery<TResult>
            where TResult : IQueryResult
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return handler.Handle(query, cancellationToken);
        }
    }
}
