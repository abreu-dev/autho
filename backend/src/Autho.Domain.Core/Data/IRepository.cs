using Autho.Domain.Core.Entities;

namespace Autho.Domain.Core.Data
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
