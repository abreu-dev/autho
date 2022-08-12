using Autho.Application.Contracts.Integration;

namespace Autho.Application.Queries.Integrations.Interfaces
{
    public interface IIntegrationAppQuery
    {
        IntegrationDto? Get(Guid integrationId);
    }
}
