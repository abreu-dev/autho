using Autho.Domain.Entities;

namespace Autho.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAuthenticationToken(UserDomain user);
    }
}
