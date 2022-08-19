using Autho.Framework.Domain.Messaging.Requests.Interfaces;

namespace Autho.Framework.Domain.Messaging.Requests
{
    public abstract class Query<TResult> : IQuery<TResult> where TResult : IQueryResult
    {
    }
}
