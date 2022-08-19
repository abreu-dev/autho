using Autho.Framework.Domain.Messaging.Requests.Interfaces;

namespace Autho.Framework.Domain.Messaging.Handlers.Interfaces
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command, CancellationToken cancellationToken = default);
    }
}
