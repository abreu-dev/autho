using Autho.Domain.Core.Validation;
using Autho.Domain.Entities;

namespace Autho.Application.Interfaces
{
    public interface IAuthenticationService
    {
        IResult<UserDomain> Authenticate(string login, string password);
    }
}
