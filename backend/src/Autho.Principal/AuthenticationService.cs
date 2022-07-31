namespace Autho.Principal
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IResult<UserDomain> Authenticate(string login, string password)
        {
            var user = _userRepository.GetByLoginAndPassword(login, password);

            if (user == null)
            {
                return new Result<UserDomain>(ResultType.Failure, 
                    new ResultError("LoginFailed", "Login Failed", "The username or password informed was incorrect."));
            }

            return new Result<UserDomain>(user, ResultType.Success);
        }
    }
}
