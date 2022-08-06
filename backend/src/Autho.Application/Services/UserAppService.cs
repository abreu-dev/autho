using Autho.Application.Contracts;
using Autho.Application.Services.Interfaces;
using Autho.Domain.Core.MediatorHandler;
using Autho.Domain.Core.Notifications;
using Autho.Domain.Entities;
using Autho.Domain.Repositories;
using Autho.Domain.Validations.Interfaces;
using Autho.Infra.CrossCutting.Globalization;
using Autho.Infra.CrossCutting.Globalization.Resources;

namespace Autho.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidation _userValidation;
        private readonly IMediatorHandler _mediator;

        public UserAppService(IUserRepository userRepository, 
                              IUserValidation userValidation, 
                              IMediatorHandler mediator)
        {
            _userRepository = userRepository;
            _userValidation = userValidation;
            _mediator = mediator;
        }

        public async Task Add(UserCreationDto creationDto)
        {
            var profiles = creationDto.Profiles.Select(x => new ProfileDomain(x.Id)).ToList();
            var user = new UserDomain(creationDto.Name, creationDto.Email, creationDto.Login, creationDto.Password, Language.EN, profiles);

            if (!user.IsValid(_userValidation))
            {
                foreach (var error in user.ValidationResult.Errors)
                {
                    await _mediator.RaiseNotification(new DomainNotification(error.ErrorCode, error.CustomState.ToString() ?? "", error.ErrorMessage));
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

            if (!user.IsValid(_userValidation))
            {
                foreach (var error in user.ValidationResult.Errors)
                {
                    await _mediator.RaiseNotification(new DomainNotification(error.ErrorCode, error.CustomState.ToString() ?? "", error.ErrorMessage));
                }
                return;
            }

            if (!_userRepository.Exists(id))
            {
                var message = string.Format(AuthoResource.NotFound, AuthoResource.User);
                await _mediator.RaiseNotification(new DomainNotification("NotFound", "NotFound", message));
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
                var message = string.Format(AuthoResource.FieldMustBeUnique, AuthoResource.Name);
                await _mediator.RaiseNotification(new DomainNotification("FieldMustBeUnique", "Name - FieldMustBeUnique", message));
                return false;
            }

            return true;
        }

        private async Task<bool> IsEmailInUse(Guid id, string email)
        {
            if (_userRepository.ExistsEmail(id, email))
            {
                var message = string.Format(AuthoResource.FieldMustBeUnique, AuthoResource.Email);
                await _mediator.RaiseNotification(new DomainNotification("FieldMustBeUnique", "Email - FieldMustBeUnique", message));
                return false;
            }

            return true;
        }

        private async Task<bool> IsLoginInUse(Guid id, string login)
        {
            if (_userRepository.ExistsLogin(id, login))
            {
                var message = string.Format(AuthoResource.FieldMustBeUnique, AuthoResource.Login);
                await _mediator.RaiseNotification(new DomainNotification("FieldMustBeUnique", "Login - FieldMustBeUnique", message));
                return false;
            }

            return true;
        }
    }
}
