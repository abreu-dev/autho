using Autho.Domain.Core.Validations;
using Autho.Domain.Entities;
using Autho.Domain.Validations.Interfaces;
using Autho.Infra.CrossCutting.Globalization.Services.Interfaces;
using FluentValidation;

namespace Autho.Domain.Validations
{
    public class ProfileValidation : DomainValidation<ProfileDomain>, IProfileValidation
    {
        public ProfileValidation(IGlobalizationService globalizationService) : base(globalizationService)
        {
            SetDomainRules();
        }

        protected override void SetDomainRules()
        {
            var missingNameError = _globalizationService.ErrorMessage(
                _globalizationService.MissingValue, _globalizationService.Name);

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode(missingNameError.Type)
                .WithState(_ => missingNameError.Error)
                .WithMessage(missingNameError.Detail);
        }
    }
}
