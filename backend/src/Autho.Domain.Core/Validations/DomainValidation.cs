using Autho.Domain.Core.Entities;
using Autho.Domain.Core.Validations.Interfaces;
using Autho.Infra.CrossCutting.Globalization.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace Autho.Domain.Core.Validations
{
    public abstract class DomainValidation<TBaseDomain> : AbstractValidator<TBaseDomain>, IDomainValidation<TBaseDomain>
        where TBaseDomain : BaseDomain
    {
        protected readonly IGlobalizationService _globalizationService;

        public ValidationResult ValidationResult { get; private set; }

        protected DomainValidation(IGlobalizationService globalizationService)
        {
            _globalizationService = globalizationService;
            ValidationResult = new ValidationResult();
        }

        protected abstract void SetDomainRules();

        public bool IsValid(TBaseDomain domain)
        {
            ValidationResult = Validate(domain);
            return ValidationResult.IsValid;
        }
    }
}
