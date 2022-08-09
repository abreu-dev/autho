using Autho.Application.Services.Interfaces;
using Autho.Domain.Core.Validations;
using Autho.Domain.Core.Validations.Interfaces;
using Autho.Domain.Entities;
using Autho.Domain.Repositories;
using Autho.Infra.CrossCutting.Globalization.Services.Interfaces;

namespace Autho.Application.Services
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGlobalizationService _globalizationService;

        public AuthenticationAppService(IUserRepository userRepository, 
                                        IGlobalizationService globalizationService)
        {
            _userRepository = userRepository;
            _globalizationService = globalizationService;
        }

        public IResult<UserDomain> Authenticate(string login, string password)
        {
            var user = _userRepository.GetByLoginAndPassword(login, password);

            if (user == null)
            {
                return new Result<UserDomain>(ResultType.Failure,
                    new ResultError(_globalizationService.ErrorMessage(_globalizationService.LoginFailed)));
            }

            _userRepository.UpdateLastAccess(user.Id);
            return new Result<UserDomain>(user, ResultType.Success);
        }
    }
}
