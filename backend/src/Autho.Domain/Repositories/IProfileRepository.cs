using Autho.Domain.Core.Data;
using Autho.Domain.Entities;

namespace Autho.Domain.Repositories
{
    public interface IProfileRepository : IRepository<ProfileDomain>
    {
        bool ExistsName(Guid id, string name);

        ProfileDomain? GetWithPermissions(Guid id);
        IEnumerable<ProfileDomain> GetAllWithPermissions();

        void UpdateProfile(ProfileDomain domain);
    }
}
