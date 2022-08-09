using Autho.Domain.Core.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Autho.Domain.Core.Validations.Interfaces
{
    public interface IDomainValidation<TBaseDomain> : IValidator<TBaseDomain>
        where TBaseDomain : BaseDomain
    {
        ValidationResult ValidationResult { get; }

        bool IsValid(TBaseDomain domain);
    }
}
