using Autho.Domain.Core.Data;
using Autho.Domain.Entities.Integration;

namespace Autho.Domain.Repositories.Integration
{
    public interface IIntegrationRepository : IRepository<IntegrationDomain>
    {
        IntegrationDomain? FirstPendingIntegrationUser();
    }
}
