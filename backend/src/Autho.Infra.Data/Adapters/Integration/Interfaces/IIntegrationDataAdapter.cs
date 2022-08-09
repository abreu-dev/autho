using Autho.Domain.Entities.Integration;
using Autho.Infra.Data.Core.Adapter;
using Autho.Infra.Data.Entities.Integration;

namespace Autho.Infra.Data.Adapters.Integration.Interfaces
{
    public interface IIntegrationDataAdapter : IDataAdapter<IntegrationDomain, IntegrationData>
    {
    }
}
