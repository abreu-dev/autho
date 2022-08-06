using Autho.Domain.Core.Validations.Interfaces;
using FluentValidation.Results;

namespace Autho.Domain.Core.Entities
{
    public abstract class BaseDomain
    {
        public Guid Id { get; private set; }
        public ValidationResult ValidationResult { get; protected set; }

        protected BaseDomain()
        {
            Id = Guid.NewGuid();
        }

        protected BaseDomain(Guid id)
        {
            Id = id;
        }
    }
}
