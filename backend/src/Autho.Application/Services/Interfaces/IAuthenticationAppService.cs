using Autho.Domain.Core.Validation;
using Autho.Domain.Entities;

namespace Autho.Application.Services.Interfaces
{
    public interface IAuthenticationAppService
    {
        IResult<UserDomain> Authenticate(string login, string password);
    }
}
