using Autho.Domain.Core.Data;
using Autho.Infra.Data.Core.Context;
using Autho.Infra.Data.Core.Entities;

namespace Autho.Infra.Data.Core.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly IBaseContext _context;

        public GenericRepository(IBaseContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public IQueryable<TBaseData> Query<TBaseData>() where TBaseData : BaseData
        {
            return _context.GetDbSet<TBaseData>().AsQueryable();
        }

        public void Add<TBaseData>(TBaseData data) where TBaseData : BaseData
        {
            _context.AddData(data);
        }
    }
}
