using Autho.Domain.Entities;
using Autho.Infra.CrossCutting.Globalization.Resources;
using FluentValidation;

namespace Autho.Domain.Validations.Interfaces
{
    public class ProfileValidation : AbstractValidator<ProfileDomain>, IProfileValidation
    {
        public ProfileValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Name not informed")
                .WithMessage(string.Format(AuthoResource.MissingValue, AuthoResource.Name));
        }
    }
}
