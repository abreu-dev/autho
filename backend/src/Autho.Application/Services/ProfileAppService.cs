using Autho.Application.Contracts.Profile;
using Autho.Application.Services.Interfaces;
using Autho.Domain.Core.MediatorHandler;
using Autho.Domain.Core.Notifications;
using Autho.Domain.Entities;
using Autho.Domain.Repositories;
using Autho.Domain.Validations.Interfaces;
using Autho.Infra.CrossCutting.Globalization.Services.Interfaces;

namespace Autho.Application.Services
{
    public class ProfileAppService : IProfileAppService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IProfileValidation _profileValidation;
        private readonly IMediatorHandler _mediator;
        private readonly IGlobalizationService _globalizationService;

        public ProfileAppService(IProfileRepository profileRepository,
                                 IProfileValidation profileValidation,
                                 IMediatorHandler mediator,
                                 IGlobalizationService globalizationService)
        {
            _profileRepository = profileRepository;
            _profileValidation = profileValidation;
            _mediator = mediator;
            _globalizationService = globalizationService;
        }

        public async Task Add(ProfileCreationDto creationDto)
        {
            var permissions = creationDto.Permissions.Select(x => new PermissionDomain(x.Id)).ToList();
            var profile = new ProfileDomain(creationDto.Name, permissions);

            if (!_profileValidation.IsValid(profile))
            {
                foreach (var error in _profileValidation.ValidationResult.Errors)
                {
                    await _mediator.RaiseNotification(new DomainNotification(error.ErrorCode, error.CustomState.ToString() ?? "", error.ErrorMessage));
                }
                return;
            }

            if (!await IsNameInUse(profile.Id, creationDto.Name))
            {
                return;
            }

            _profileRepository.Add(profile);
            _profileRepository.UnitOfWork.Complete();
        }

        public async Task Update(Guid id, ProfileCreationDto creationDto)
        {
            var permissions = creationDto.Permissions.Select(x => new PermissionDomain(x.Id)).ToList();
            var profile = new ProfileDomain(id, creationDto.Name, permissions);

            if (!_profileValidation.IsValid(profile))
            {
                foreach (var error in _profileValidation.ValidationResult.Errors)
                {
                    await _mediator.RaiseNotification(new DomainNotification(error.ErrorCode, error.CustomState.ToString() ?? "", error.ErrorMessage));
                }
                return;
            }

            if (!_profileRepository.Exists(id))
            {
                await _mediator.RaiseNotification(new DomainNotification(
                    _globalizationService.ErrorMessage(_globalizationService.NotFound, _globalizationService.Profile)));
                return;
            }

            if (!await IsNameInUse(profile.Id, creationDto.Name))
            {
                return;
            }

            _profileRepository.UpdateProfile(profile);
            _profileRepository.UnitOfWork.Complete();
        }

        public Task Remove(Guid id)
        {
            _profileRepository.Delete(id);
            _profileRepository.UnitOfWork.Complete();

            return Task.CompletedTask;
        }

        private async Task<bool> IsNameInUse(Guid id, string name)
        {
            if (_profileRepository.ExistsName(id, name))
            {
                await _mediator.RaiseNotification(new DomainNotification(
                    _globalizationService.ErrorMessage(_globalizationService.UniqueValue, _globalizationService.Name)));
                return false;
            }

            return true;
        }
    }
}
