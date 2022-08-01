﻿using Autho.Application.Contracts;
using Autho.Application.Interfaces;
using Autho.Domain.Core.MediatorHandler;
using Autho.Domain.Core.Notifications;
using Autho.Domain.Entities;
using Autho.Domain.Repositories;
using Autho.Infra.CrossCutting.Globalization.Resources;

namespace Autho.Application.Services
{
    public class ProfileAppService : IProfileAppService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMediatorHandler _mediator;

        public ProfileAppService(IProfileRepository profileRepository, 
                                 IMediatorHandler mediator)
        {
            _profileRepository = profileRepository;
            _mediator = mediator;
        }

        public async Task Add(ProfileCreationDto creationDto)
        {
            var permissions = creationDto.Permissions.Select(x => new PermissionDomain(x.Id)).ToList();
            var profile = new ProfileDomain(creationDto.Name, permissions);

            if (!await IsNameValid(profile.Id, creationDto.Name))
            {
                return;
            }


            _profileRepository.Add(profile);
            _profileRepository.UnitOfWork.Complete();
        }

        public async Task Update(Guid id, ProfileCreationDto creationDto)
        {
            var profile = _profileRepository.GetWithPermissions(id);
            if (profile == null)
            {
                var message = string.Format(AuthoResource.NotFound, AuthoResource.Profile);
                await _mediator.RaiseNotification(new DomainNotification("NotFound", "NotFound", message));
                return;
            }

            if (!await IsNameValid(profile.Id, creationDto.Name))
            {
                return;
            }

            profile.UpdateName(creationDto.Name);

            profile.ClearPermissions();
            profile.AddPermissions(creationDto.Permissions.Select(x => new PermissionDomain(x.Id)).ToList());

            _profileRepository.UpdateProfile(profile);
            _profileRepository.UnitOfWork.Complete();
        }

        public Task Remove(Guid id)
        {
            _profileRepository.Delete(id);
            _profileRepository.UnitOfWork.Complete();

            return Task.CompletedTask;
        }

        private async Task<bool> IsNameValid(Guid id, string name)
        {
            if (_profileRepository.ExistsName(id, name))
            {
                var message = string.Format(AuthoResource.FieldMustBeUnique, AuthoResource.Name);
                await _mediator.RaiseNotification(new DomainNotification("FieldMustBeUnique", "Name - FieldMustBeUnique", message));
                return false;
            }

            return true;
        }
    }
}
