using Autho.Core.Enums;
using Autho.Domain.Entities.Integration;
using Autho.Domain.Repositories.Integration;
using Autho.Infra.Data.Adapters.Integration.Interfaces;
using Autho.Infra.Data.Context;
using Autho.Infra.Data.Core.Repositories;
using Autho.Infra.Data.Entities.Integration;
using Microsoft.EntityFrameworkCore;

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

        public IntegrationDomain? FirstPendingIntegrationUser()
        {
            var data = _context.Query<IntegrationData>()
                .Include(x => x.Users)
                .Where(x => x.Users.Any() && x.Status == IntegrationStatus.None)
                .OrderByDescending(x => x.CreatedDate)
                .FirstOrDefault();

            return _adapter.Transform(data);
        }
    }
}
