using Autho.Application.Contracts.Integration;
using Autho.Application.Services.Integration.Interfaces;
using Autho.Domain.Entities.Integration;
using Autho.Domain.Repositories.Integration;
using Autho.Infra.CrossCutting.Integration.Integrations.User.Interfaces;

namespace Autho.Application.Services.Integration
{
    public class IntegrationAppService : IIntegrationAppService
    {
        private readonly IIntegrationRepository _integrationRepository;
        private readonly IIntegrationUserPipeline _integrationUserPipeline;

        public IntegrationAppService(IIntegrationRepository integrationRepository,
                                     IIntegrationUserPipeline integrationUserPipeline)
        {
            _integrationRepository = integrationRepository;
            _integrationUserPipeline = integrationUserPipeline;
        }

        #region User
        public Task ProcessUser()
        {
            _integrationUserPipeline.Execute();
            return Task.CompletedTask;
        }

        public Task Create(Guid integrationId, IEnumerable<IntegrationUserDto> integrationDtos)
        {
            var integrationUsers = MapToDomain(integrationId, integrationDtos).ToList();

            var integration = new IntegrationDomain(integrationId, integrationUsers);

            _integrationRepository.Add(integration);
            _integrationRepository.UnitOfWork.Complete();

            return Task.CompletedTask;
        }

        private IEnumerable<IntegrationUserDomain> MapToDomain(Guid integrationId, IEnumerable<IntegrationUserDto> integrationDtos)
        {
            return integrationDtos.Select(dto =>
            {
                return new IntegrationUserDomain(integrationId, dto.Name, dto.Email, dto.Login, dto.Password, dto.Language);
            });
        }
        #endregion
    }
}
