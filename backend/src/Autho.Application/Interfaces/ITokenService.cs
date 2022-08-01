using Autho.Domain.Entities;

namespace Autho.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateAuthenticationToken(UserDomain user);
    }
}
