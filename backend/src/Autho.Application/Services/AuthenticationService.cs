﻿using Autho.Application.Interfaces;
using Autho.Domain.Core.Validation;
using Autho.Domain.Entities;
using Autho.Domain.Repositories;
using Autho.Infra.CrossCutting.Globalization.Resources;

namespace Autho.Application.Services
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
                    new ResultError("LoginFailed", "Login Failed", AuthoResource.LoginFailed));
            }

            return new Result<UserDomain>(user, ResultType.Success);
        }
    }
}
