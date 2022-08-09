using Autho.Domain.Core.Validations;
using Autho.Domain.Entities;
using Autho.Domain.Validations.Interfaces;
using Autho.Infra.CrossCutting.Globalization.Services.Interfaces;
using FluentValidation;

namespace Autho.Domain.Validations
{
    public class UserValidation : DomainValidation<UserDomain>, IUserValidation
    {
        public UserValidation(IGlobalizationService globalizationService) : base(globalizationService)
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

            var missingEmailError = _globalizationService.ErrorMessage(
                _globalizationService.MissingValue, _globalizationService.Email);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithErrorCode(missingEmailError.Type)
                .WithState(_ => missingEmailError.Error)
                .WithMessage(missingEmailError.Detail);

            var missingLoginError = _globalizationService.ErrorMessage(
                _globalizationService.MissingValue, _globalizationService.Login);

            RuleFor(x => x.Login)
                .NotEmpty()
                .WithErrorCode(missingLoginError.Type)
                .WithState(_ => missingLoginError.Error)
                .WithMessage(missingLoginError.Detail);

            var missingPasswordError = _globalizationService.ErrorMessage(
                _globalizationService.MissingValue, _globalizationService.Password);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithErrorCode(missingPasswordError.Type)
                .WithState(_ => missingPasswordError.Error)
                .WithMessage(missingPasswordError.Detail);
        }
    }
}
