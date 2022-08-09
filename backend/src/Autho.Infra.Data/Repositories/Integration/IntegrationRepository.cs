using Autho.Domain.Entities.Integration;
using Autho.Domain.Repositories.Integration;
using Autho.Infra.Data.Adapters.Integration.Interfaces;
using Autho.Infra.Data.Context;
using Autho.Infra.Data.Core.Repositories;
using Autho.Infra.Data.Entities.Integration;

namespace Autho.Infra.Data.Repositories.Integration
{
    public class IntegrationRepository : Repository<IntegrationDomain, IntegrationData>,
        IIntegrationRepository
    {
        public IntegrationRepository(IAuthoContext context,
                                     IIntegrationDataAdapter adapter)
            : base(context, adapter)
        {
        }
    }
}
