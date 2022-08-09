using Autho.Domain.Entities;
using Autho.Domain.Validations.Interfaces;
using Autho.Infra.CrossCutting.Globalization.Resources;
using Autho.Infra.CrossCutting.Globalization.Services.Interfaces;
using FluentValidation;

namespace Autho.Domain.Validations
{
    public class UserValidation : AbstractValidator<UserDomain>, IUserValidation
    {
        public UserValidation(IGlobalizationService globalizationService)
        {
            var missingNameError = globalizationService.ErrorMessage(globalizationService.MissingValue, globalizationService.Name);
            var missingEmailError = globalizationService.ErrorMessage(globalizationService.MissingValue, globalizationService.Email);
            var missingLoginError = globalizationService.ErrorMessage(globalizationService.MissingValue, globalizationService.Login);
            var missingPasswordError = globalizationService.ErrorMessage(globalizationService.MissingValue, globalizationService.Password);

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode(missingNameError.Type)
                .WithState(_ => missingNameError.Error)
                .WithMessage(missingNameError.Detail);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithErrorCode(missingEmailError.Type)
                .WithState(_ => missingEmailError.Error)
                .WithMessage(missingEmailError.Detail);

            RuleFor(x => x.Login)
                .NotEmpty()
                .WithErrorCode(missingLoginError.Type)
                .WithState(_ => missingLoginError.Error)
                .WithMessage(missingLoginError.Detail);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithErrorCode(missingPasswordError.Type)
                .WithState(_ => missingPasswordError.Error)
                .WithMessage(missingPasswordError.Detail);
        }
    }
}
