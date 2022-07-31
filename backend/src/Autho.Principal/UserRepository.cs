using Microsoft.EntityFrameworkCore;

namespace Autho.Principal
{
    public class UserRepository : Repository<UserDomain, UserData>, IUserRepository
    {
        public UserRepository(IAuthoContext context,
                              IUserTransformAdapter adapter) 
            : base(context, adapter)
        {
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
    }
}
