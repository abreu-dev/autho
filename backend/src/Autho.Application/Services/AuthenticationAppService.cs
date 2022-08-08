using Autho.Application.Services.Interfaces;
using Autho.Domain.Core.Validations;
using Autho.Domain.Core.Validations.Interfaces;
using Autho.Domain.Entities;
using Autho.Domain.Repositories;
using Autho.Infra.CrossCutting.Globalization.Resources;

namespace Autho.Application.Services
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IResult<UserDomain> Authenticate(string login, string password)
        {
            var user = _userRepository.GetByLoginAndPassword(login, password);

            if (user == null)
            {
                return new Result<UserDomain>(ResultType.Failure,
                    new ResultError("LoginFailed", "Login Failed", AuthoResource.LoginFailed));
            }

            _userRepository.UpdateLastAccess(user.Id);
            return new Result<UserDomain>(user, ResultType.Success);
        }
    }
}
