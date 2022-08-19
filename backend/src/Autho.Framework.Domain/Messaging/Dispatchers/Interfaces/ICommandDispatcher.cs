using Autho.Framework.Domain.Messaging.Requests.Interfaces;

namespace Autho.Framework.Domain.Messaging.Dispatchers.Interfaces
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand;
    }
}
