using Autho.Domain.Entities;

namespace Autho.Application.Services.Interfaces
{
    public interface ITokenAppService
    {
        string GenerateAuthenticationToken(UserDomain user);
    }
}
