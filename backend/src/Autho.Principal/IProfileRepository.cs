namespace Autho.Principal
{
    public interface IProfileRepository : IRepository<ProfileDomain> 
    {
        bool ExistsName(Guid id, string name);

        ProfileDomain? GetWithPermissions(Guid id);
        IEnumerable<ProfileDomain> GetAllWithPermissions();

        void UpdateProfile(ProfileDomain domain);
    }
}
