using Autho.Domain.Core.Validations.Interfaces;
using Autho.Domain.Entities;

namespace Autho.Application.Services.Interfaces
{
    public interface IAuthenticationAppService
    {
        IResult<UserDomain> Authenticate(string login, string password);
    }
}
