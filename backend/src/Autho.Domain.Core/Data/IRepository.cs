namespace Autho.Principal
{
    public interface IRepository<TBaseDomain> where TBaseDomain : BaseDomain
    {
        IUnitOfWork UnitOfWork { get; }

        IEnumerable<TBaseDomain> GetAll();
        TBaseDomain? GetById(Guid id);

        void Add(TBaseDomain domain);
        void Update(TBaseDomain domain);
        void Delete(Guid id);
    }
}
