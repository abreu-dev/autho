using Autho.Framework.Domain.Messaging.Dispatchers.Interfaces;
using Autho.Framework.Domain.Messaging.Handlers.Interfaces;
using Autho.Framework.Domain.Messaging.Requests.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Autho.Framework.Domain.Messaging.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task Dispatch<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            return handler.Handle(command, cancellationToken);
        }
    }
}
