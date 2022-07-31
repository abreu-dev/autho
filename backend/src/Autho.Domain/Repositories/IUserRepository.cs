namespace Autho.Principal
{
    public interface IUserRepository : IRepository<UserDomain> 
    {
        UserDomain? GetByLoginAndPassword(string login, string password);
        UserDomain? GetWithPermissions(Guid id);
    }
}
