namespace Autho.Principal
{
    public interface IGenericRepository
    {
        IUnitOfWork UnitOfWork { get; }

        IEnumerable<TBaseData> GetAll<TBaseData>() where TBaseData : BaseData;
        TBaseData? GetById<TBaseData>(Guid id) where TBaseData : BaseData;
        IQueryable<TBaseData> Query<TBaseData>() where TBaseData : BaseData;

        void Add<TBaseData>(TBaseData data) where TBaseData : BaseData;
        void Update<TBaseData>(TBaseData data) where TBaseData : BaseData;
        void Delete<TBaseData>(Guid id) where TBaseData : BaseData;
    }
}
