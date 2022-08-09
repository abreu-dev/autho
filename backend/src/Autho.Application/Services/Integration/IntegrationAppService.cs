using Autho.Application.Contracts.Integration;
using Autho.Application.Services.Integration.Interfaces;
using Autho.Domain.Entities.Integration;
using Autho.Domain.Repositories.Integration;

namespace Autho.Application.Services.Integration
{
    public class IntegrationAppService : IIntegrationAppService
    {
        private readonly IIntegrationRepository _integrationRepository;

        public IntegrationAppService(IIntegrationRepository integrationRepository)
        {
            _integrationRepository = integrationRepository;
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
    }
}
