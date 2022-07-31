using Microsoft.EntityFrameworkCore;

namespace Autho.Principal
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
