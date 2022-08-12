using Autho.Application.Contracts.User;
using Autho.Application.Services.Interfaces;
using Autho.Domain.Core.MediatorHandler;
using Autho.Domain.Core.Notifications;
using Autho.Domain.Entities;
using Autho.Domain.Repositories;
using Autho.Domain.Validations.Interfaces;
using Autho.Infra.CrossCutting.Globalization;
using Autho.Infra.CrossCutting.Globalization.Services.Interfaces;

namespace Autho.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidation _userValidation;
        private readonly IMediatorHandler _mediator;
        private readonly IGlobalizationService _globalizationService;

        public UserAppService(IUserRepository userRepository,
                              IUserValidation userValidation,
                              IMediatorHandler mediator,
                              IGlobalizationService globalizationService)
        {
            _userRepository = userRepository;
            _userValidation = userValidation;
            _mediator = mediator;
            _globalizationService = globalizationService;
        }

        public async Task Add(UserCreationDto creationDto)
        {
            var profiles = creationDto.Profiles.Select(x => new ProfileDomain(x.Id)).ToList();
            var user = new UserDomain(creationDto.Name, creationDto.Email, creationDto.Login, creationDto.Password, Language.EN, profiles);

            if (!_userValidation.IsValid(user))
            {
                foreach (var error in _userValidation.ValidationResult.Errors)
                {
                    await _mediator.RaiseNotification(new DomainNotification(error.ErrorCode, error.CustomState.ToString() ?? string.Empty, error.ErrorMessage));
                }
                return;
            }

            if (!await IsFieldsInUse(user.Id, creationDto))
            {
                return;
            }

            _userRepository.Add(user);
            _userRepository.UnitOfWork.Complete();
        }

        public async Task Update(Guid id, UserCreationDto creationDto)
        {
            var profiles = creationDto.Profiles.Select(x => new ProfileDomain(x.Id)).ToList();
            var user = new UserDomain(id, creationDto.Name, creationDto.Email, creationDto.Login, creationDto.Password, Language.EN, profiles);

            if (!_userValidation.IsValid(user))
            {
                foreach (var error in _userValidation.ValidationResult.Errors)
                {
                    await _mediator.RaiseNotification(new DomainNotification(error.ErrorCode, error.CustomState.ToString() ?? "", error.ErrorMessage));
                }
                return;
            }

            if (!_userRepository.Exists(id))
            {
                await _mediator.RaiseNotification(new DomainNotification(
                    _globalizationService.ErrorMessage(_globalizationService.NotFound, _globalizationService.User)));
                return;
            }

            if (!await IsFieldsInUse(user.Id, creationDto))
            {
                return;
            }

            _userRepository.UpdateUser(user);
            _userRepository.UnitOfWork.Complete();
        }

        public Task Remove(Guid id)
        {
            _userRepository.Delete(id);
            _userRepository.UnitOfWork.Complete();

            return Task.CompletedTask;
        }

        private async Task<bool> IsFieldsInUse(Guid id, UserCreationDto creationDto)
        {
            if (!await IsNameInUse(id, creationDto.Name))
            {
                return false;
            }

            if (!await IsEmailInUse(id, creationDto.Email))
            {
                return false;
            }

            if (!await IsLoginInUse(id, creationDto.Login))
            {
                return false;
            }

            return true;
        }

        private async Task<bool> IsNameInUse(Guid id, string name)
        {
            if (_userRepository.ExistsName(id, name))
            {
                await _mediator.RaiseNotification(new DomainNotification(
                    _globalizationService.ErrorMessage(_globalizationService.UniqueValue, _globalizationService.Name)));
                return false;
            }

            return true;
        }

        private async Task<bool> IsEmailInUse(Guid id, string email)
        {
            if (_userRepository.ExistsEmail(id, email))
            {
                await _mediator.RaiseNotification(new DomainNotification(
                    _globalizationService.ErrorMessage(_globalizationService.UniqueValue, _globalizationService.Email)));
                return false;
            }

            return true;
        }

        private async Task<bool> IsLoginInUse(Guid id, string login)
        {
            if (_userRepository.ExistsLogin(id, login))
            {
                await _mediator.RaiseNotification(new DomainNotification(
                    _globalizationService.ErrorMessage(_globalizationService.UniqueValue, _globalizationService.Login)));
                return false;
            }

            return true;
        }
    }
}
