using Autho.Domain.Entities;
using Autho.Domain.Validations.Interfaces;
using Autho.Infra.CrossCutting.Globalization.Services.Interfaces;
using FluentValidation;

namespace Autho.Domain.Validations
{
    public class ProfileValidation : AbstractValidator<ProfileDomain>, IProfileValidation
    {
        public ProfileValidation(IGlobalizationService globalizationService)
        {
            var missingNameError = globalizationService.ErrorMessage(globalizationService.MissingValue, globalizationService.Name);

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode(missingNameError.Type)
                .WithState(_ => missingNameError.Error)
                .WithMessage(missingNameError.Detail);
        }
    }
}
