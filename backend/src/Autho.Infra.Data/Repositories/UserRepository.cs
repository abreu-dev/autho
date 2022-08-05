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
    }
}
