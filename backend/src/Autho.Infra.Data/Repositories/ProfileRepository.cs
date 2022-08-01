using Autho.Domain.Entities;
using Autho.Domain.Repositories;
using Autho.Infra.Data.Adapters.Interfaces;
using Autho.Infra.Data.Context;
using Autho.Infra.Data.Core.Repositories;
using Autho.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autho.Infra.Data.Repositories
{
    public class ProfileRepository : Repository<ProfileDomain, ProfileData>, IProfileRepository
    {
        public ProfileRepository(IAuthoContext context,
                                 IProfileDataAdapter adapter)
            : base(context, adapter)
        {
        }

        public bool ExistsName(Guid id, string name)
        {
            return _context.Query<ProfileData>()
                .AsNoTracking()
                .Any(x => x.Id != id && x.Name == name);
        }

        public ProfileDomain? GetWithPermissions(Guid id)
        {
            var profile = _context.Query<ProfileData>()
                .AsNoTracking()
                .Include(x => x.Permissions)
                .ThenInclude(x => x.Permission)
                .FirstOrDefault(x => x.Id == id);

            if (profile == null)
            {
                return null;
            }

            return _adapter.Transform(profile);
        }

        public IEnumerable<ProfileDomain> GetAllWithPermissions()
        {
            var profiles = _context.Query<ProfileData>()
                .AsNoTracking()
                .Include(x => x.Permissions)
                .ThenInclude(x => x.Permission);

            return _adapter.Transform(profiles);
        }

        public void UpdateProfile(ProfileDomain domain)
        {
            var profile = _adapter.Transform(domain);

            var existingProfile = _context.Query<ProfileData>()
                .Where(x => x.Id == profile.Id)
                .Include(x => x.Permissions)
                .ThenInclude(x => x.Permission)
                .SingleOrDefault();

            if (existingProfile != null)
            {
                _context.GetDbEntry(existingProfile).CurrentValues.SetValues(profile);
                _context.UpdateState(existingProfile);

                foreach (var existingPermission in existingProfile.Permissions.ToList())
                {
                    if (!profile.Permissions.Any(c => c.PermissionId == existingPermission.PermissionId))
                    {
                        existingProfile.Permissions.Remove(existingPermission);
                    }
                }

                foreach (var permission in profile.Permissions)
                {
                    var existingPermission = existingProfile.Permissions.SingleOrDefault(c => c.PermissionId == permission.PermissionId);

                    if (existingPermission == null)
                    {
                        existingProfile.Permissions.Add(permission);
                    }
                }
            }
        }
    }
}
