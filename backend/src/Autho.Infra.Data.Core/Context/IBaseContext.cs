using Autho.Domain.Core.Data;
using Autho.Infra.Data.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Autho.Infra.Data.Core.Context
{
    public interface IBaseContext : IUnitOfWork
    {
        DbSet<TBaseData> GetDbSet<TBaseData>() where TBaseData : BaseData;
        EntityEntry<TBaseData> GetDbEntry<TBaseData>(TBaseData data) where TBaseData : BaseData;
        IQueryable<TBaseData> Query<TBaseData>() where TBaseData : BaseData;

        void AddData<TBaseData>(TBaseData data) where TBaseData : BaseData;
        void UpdateData<TBaseData>(TBaseData data) where TBaseData : BaseData;
        void UpdateState<TBaseData>(TBaseData data) where TBaseData : BaseData;
        void DeleteData<TBaseData>(TBaseData data) where TBaseData : BaseData;
    }
}
