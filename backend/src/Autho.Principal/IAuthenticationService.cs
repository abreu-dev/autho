namespace Autho.Principal
{
    public interface IAuthenticationService
    {
        IResult<UserDomain> Authenticate(string login, string password);
    }
}
