using Autho.Framework.Domain.Validators;
using FluentValidation.Results;

namespace Autho.Framework.Domain.Messaging.Requests
{
    public abstract class ValidatableCommand<TCommandValidator> : Command
        where TCommandValidator : ValidatableCommand<TCommandValidator>
    {
        public ValidationResult ValidationResult { get; protected set; }

        protected ValidatableCommand()
        {
            ValidationResult = new ValidationResult();
        }

        public bool IsValid()
        {
            ValidationResult = GetValidator().Validate((TCommandValidator)this);
            return ValidationResult.IsValid;
        }

        public abstract CommandValidator<TCommandValidator> GetValidator();
    }
}
