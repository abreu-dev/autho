using Autho.Domain.Core.Data;
using Autho.Domain.Entities;

namespace Autho.Domain.Repositories
{
    public interface IPermissionRepository : IRepository<PermissionDomain>
    {
        bool Exists(Guid id);
    }
}
