namespace Autho.Principal
{
    public interface IPermissionRepository : IRepository<PermissionDomain> 
    {
        bool Exists(Guid id);
    }
}
