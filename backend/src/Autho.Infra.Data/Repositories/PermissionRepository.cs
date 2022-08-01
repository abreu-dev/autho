using Autho.Domain.Entities;
using Autho.Domain.Repositories;
using Autho.Infra.Data.Adapters.Interfaces;
using Autho.Infra.Data.Context;
using Autho.Infra.Data.Core.Repositories;
using Autho.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autho.Infra.Data.Repositories
{
    public class PermissionRepository : Repository<PermissionDomain, PermissionData>, IPermissionRepository
    {
        public PermissionRepository(IAuthoContext context,
                                    IPermissionDataAdapter adapter)
            : base(context, adapter)
        {
        }

        public bool Exists(Guid id)
        {
            return _context.Query<PermissionData>()
                .AsNoTracking()
                .Any(x => x.Id == id);
        }
    }
}
