using Autho.Domain.Entities;
using Autho.Domain.Validations.Interfaces;
using Autho.Infra.CrossCutting.Globalization.Resources;
using FluentValidation;

namespace Autho.Domain.Validations
{
    public class UserValidation : AbstractValidator<UserDomain>, IUserValidation
    {
        public UserValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Name not informed")
                .WithMessage(string.Format(AuthoResource.MissingValue, AuthoResource.Name));

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Email not informed")
                .WithMessage(string.Format(AuthoResource.MissingValue, AuthoResource.Email));

            RuleFor(x => x.Login)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Login not informed")
                .WithMessage(string.Format(AuthoResource.MissingValue, AuthoResource.Login));

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Password not informed")
                .WithMessage(string.Format(AuthoResource.MissingValue, AuthoResource.Password));
        }
    }
}
