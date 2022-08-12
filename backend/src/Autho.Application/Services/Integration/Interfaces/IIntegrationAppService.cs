using Autho.Application.Contracts.Integration;

namespace Autho.Application.Services.Integration.Interfaces
{
    public interface IIntegrationAppService
    {
        Task ProcessUser();
        Task Create(Guid integrationId, IEnumerable<IntegrationUserDto> integrationDtos);
    }
}
