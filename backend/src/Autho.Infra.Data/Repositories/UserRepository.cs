using Autho.Core.Providers.Interfaces;
using Autho.Domain.Entities;
using Autho.Domain.Repositories;
using Autho.Infra.Data.Adapters.Interfaces;
using Autho.Infra.Data.Context;
using Autho.Infra.Data.Core.Repositories;
using Autho.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autho.Infra.Data.Repositories
{
    public class UserRepository : Repository<UserDomain, UserData>, IUserRepository
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public UserRepository(IAuthoContext context,
                              IUserDataAdapter adapter,
                              IDateTimeProvider dateTimeProvider)
            : base(context, adapter)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public bool ExistsName(Guid id, string name)
        {
            return _context.Query<UserData>()
                .AsNoTracking()
                .Any(x => x.Id != id && x.Name == name);
        }

        public bool ExistsEmail(Guid id, string email)
        {
            return _context.Query<UserData>()
                .AsNoTracking()
                .Any(x => x.Id != id && x.Email == email);
        }

        public bool ExistsLogin(Guid id, string login)
        {
            return _context.Query<UserData>()
                .AsNoTracking()
                .Any(x => x.Id != id && x.Login == login);
        }

        public UserDomain? GetByLoginAndPassword(string login, string password)
        {
            var user = _context.Query<UserData>()
                .AsNoTracking()
                .FirstOrDefault(x => x.Login == login && x.Password == password);

            if (user == null)
            {
                return null;
            }

            return _adapter.Transform(user);
        }

        public UserDomain? GetWithPermissions(Guid id)
        {
            var user = _context.Query<UserData>()
                .AsNoTracking()
                .Include(x => x.Profiles)
                .ThenInclude(x => x.Profile)
                .ThenInclude(x => x.Permissions)
                .ThenInclude(x => x.Permission)
                .FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            return _adapter.Transform(user);
        }

        public void UpdateLastAccess(Guid id)
        {
            var user = _context.Query<UserData>()
                .FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                user.LastAccess = _dateTimeProvider.UtcNow;
                _context.Complete();
            }
        }

        public void UpdateUser(UserDomain domain)
        {
            var user = _adapter.Transform(domain);

            var existingUser = _context.Query<UserData>()
                .Where(x => x.Id == user.Id)
                .Include(x => x.Profiles)
                .ThenInclude(x => x.Profile)
                .SingleOrDefault();

            if (existingUser != null)
            {
                _context.GetDbEntry(existingUser).CurrentValues.SetValues(user);
                _context.UpdateState(existingUser);

                foreach (var existingProfile in existingUser.Profiles.ToList())
                {
                    if (!user.Profiles.Any(c => c.ProfileId == existingProfile.ProfileId))
                    {
                        existingUser.Profiles.Remove(existingProfile);
                    }
                }

                foreach (var profile in user.Profiles)
                {
                    var existingPermission = existingUser.Profiles.SingleOrDefault(c => c.ProfileId == profile.ProfileId);

                    if (existingPermission == null)
                    {
                        existingUser.Profiles.Add(profile);
                    }
                }
            }
        }
    }
}
