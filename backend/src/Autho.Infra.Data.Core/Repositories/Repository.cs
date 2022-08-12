using Autho.Domain.Core.Data;
using Autho.Domain.Core.Entities;
using Autho.Infra.Data.Core.Adapter;
using Autho.Infra.Data.Core.Context;
using Autho.Infra.Data.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autho.Infra.Data.Core.Repositories
{
    public abstract class Repository<TBaseDomain, TBaseData> : IRepository<TBaseDomain>
        where TBaseDomain : BaseDomain
        where TBaseData : BaseData
    {
        protected readonly IBaseContext _context;
        protected readonly IDataAdapter<TBaseDomain, TBaseData> _adapter;

        private readonly DbSet<TBaseData> _dbSet;

        protected Repository(IBaseContext context,
                             IDataAdapter<TBaseDomain, TBaseData> adapter)
        {
            _context = context;
            _adapter = adapter;

            _dbSet = _context.GetDbSet<TBaseData>();
        }

        public IUnitOfWork UnitOfWork => _context;

        public IEnumerable<TBaseDomain> GetAll()
        {
            return _adapter.Transform(_dbSet.AsNoTracking());
        }

        public TBaseDomain? GetById(Guid id)
        {
            var data = _dbSet.AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (data == null)
            {
                return null;
            }

            return _adapter.Transform(data);
        }

        public bool Exists(Guid id)
        {
            return _dbSet.AsNoTracking().Any(x => x.Id == id);
        }

        public void Add(TBaseDomain domain)
        {
            var data = _adapter.Transform(domain);
            _context.AddData(data);
        }

        public void Update(TBaseDomain domain)
        {
            var data = _adapter.Transform(domain);
            _context.UpdateData(data);
        }

        public void Delete(Guid id)
        {
            var data = _dbSet.Find(id);

            if (data != null)
            {
                _context.DeleteData(data);
            }
        }
    }
}
