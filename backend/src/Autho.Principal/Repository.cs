using Microsoft.EntityFrameworkCore;

namespace Autho.Principal
{
    public abstract class Repository<TBaseDomain, TBaseData> : IRepository<TBaseDomain>
        where TBaseDomain : BaseDomain
        where TBaseData : BaseData
    {
        protected readonly IAuthoContext _context;
        protected readonly ITransformAdapter<TBaseDomain, TBaseData> _adapter;
        private readonly DbSet<TBaseData> _dbSet;

        protected Repository(IAuthoContext context, 
                             ITransformAdapter<TBaseDomain, TBaseData> adapter)
        {
            _context = context;
            _dbSet = _context.GetDbSet<TBaseData>();
            _adapter = adapter;
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

        public void Add(TBaseDomain domain)
        {
            var data = _adapter.Transform(domain);
            _context.AddData(data);
        }

        public void Update(TBaseDomain domain)
        {
            var data = _adapter.Transform(domain);
            data.OnUpdate();
            _context.UpdateData(data);

            var entry = _context.GetDbEntry(data);

            if (entry != null)
            {
                entry.Property(x => x.CreatedBy).IsModified = false;
                entry.Property(x => x.CreatedDate).IsModified = false;
            }
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
