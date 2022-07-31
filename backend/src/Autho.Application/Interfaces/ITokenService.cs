namespace Autho.Principal
{
    public interface ITokenService
    {
        string GenerateAuthenticationToken(UserDomain user);
    }
}
