using Autho.Domain.Core.Data;
using Autho.Domain.Entities;

namespace Autho.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserDomain>
    {
        bool ExistsName(Guid id, string name);
        bool ExistsEmail(Guid id, string email);
        bool ExistsLogin(Guid id, string login);

        UserDomain? GetByLoginAndPassword(string login, string password);
        UserDomain? GetWithPermissions(Guid id);

        void UpdateLastAccess(Guid id);
        void UpdateUser(UserDomain domain);
    }
}
