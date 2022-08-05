using Autho.Domain.Core.Data;
using Autho.Domain.Entities;

namespace Autho.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserDomain>
    {
        UserDomain? GetByLoginAndPassword(string login, string password);
        UserDomain? GetWithPermissions(Guid id);

        void UpdateLastAccess(Guid id);
    }
}
