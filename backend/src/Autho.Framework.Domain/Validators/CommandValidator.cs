using Autho.Framework.Domain.Messaging.Requests;
using FluentValidation;

namespace Autho.Framework.Domain.Validators
{
    public abstract class CommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : Command
    {
    }
}
