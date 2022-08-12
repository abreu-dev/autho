using Autho.Core.Extensions;
using Autho.Domain.Entities;
using Autho.Domain.Entities.Integration;
using Autho.Domain.Repositories;
using Autho.Domain.Validations.Interfaces;
using Autho.Infra.CrossCutting.Globalization;
using Autho.Infra.CrossCutting.Integration.Integrations.User.Steps.Interfaces;

namespace Autho.Infra.CrossCutting.Integration.Integrations.User.Steps
{
    public class ProcessIntegrationUserStep : IProcessIntegrationUserStep
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidation _userValidation;

        public ProcessIntegrationUserStep(IUserRepository userRepository, 
                                          IUserValidation userValidation)
        {
            _userRepository = userRepository;
            _userValidation = userValidation;
        }

        public Task<IntegrationDomain?> Execute(IntegrationDomain? data)
        {
            if (data != null)
            {
                foreach (var userIntegration in data.Users)
                {
                    var language = string.IsNullOrEmpty(userIntegration.Language) ? default : EnumExtensions.GetEnumValueFromDescription<Language>(userIntegration.Language);
                    var userDomain = new UserDomain(userIntegration.Name ?? string.Empty, 
                        userIntegration.Email ?? "", userIntegration.Login ?? string.Empty, userIntegration.Password ?? string.Empty, language, new List<ProfileDomain>());

                    if (_userValidation.IsValid(userDomain))
                    {
                        _userRepository.Add(userDomain);
                    }
                }
            }

            return Task.FromResult(data);
        }
    }
}
