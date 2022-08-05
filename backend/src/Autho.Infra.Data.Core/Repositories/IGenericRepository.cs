using Autho.Domain.Core.Data;
using Autho.Infra.Data.Core.Entities;

namespace Autho.Infra.Data.Core.Repositories
{
    public interface IGenericRepository
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<TBaseData> Query<TBaseData>() where TBaseData : BaseData;

        void Add<TBaseData>(TBaseData data) where TBaseData : BaseData;
    }
}
