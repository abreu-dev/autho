using Autho.Domain.Entities;
using FluentValidation;

namespace Autho.Domain.Validations.Interfaces
{
    public interface IProfileValidation : IValidator<ProfileDomain>
    {
    }
}
