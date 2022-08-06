using Autho.Domain.Entities;
using FluentValidation;

namespace Autho.Domain.Validations.Interfaces
{
    public interface IUserValidation : IValidator<UserDomain>
    {
    }
}
