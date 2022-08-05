using Autho.Domain.Entities;
using Autho.Domain.Repositories;
using Autho.Infra.Data.Adapters.Interfaces;
using Autho.Infra.Data.Context;
using Autho.Infra.Data.Core.Repositories;
using Autho.Infra.Data.Entities;

namespace Autho.Infra.Data.Repositories
{
    public class PermissionRepository : Repository<PermissionDomain, PermissionData>, IPermissionRepository
    {
        public PermissionRepository(IAuthoContext context,
                                    IPermissionDataAdapter adapter)
            : base(context, adapter)
        {
        }
    }
}
