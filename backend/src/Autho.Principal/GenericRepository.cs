namespace Autho.Principal
{
    public class GenericRepository : IGenericRepository
    {
        private readonly IAuthoContext _context;

        public GenericRepository(IAuthoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public IEnumerable<TBaseData> GetAll<TBaseData>() where TBaseData : BaseData
        {
            return _context.GetDbSet<TBaseData>();
        }

        public TBaseData? GetById<TBaseData>(Guid id) where TBaseData : BaseData
        {
            return _context.GetDbSet<TBaseData>().Find(id);
        }

        public IQueryable<TBaseData> Query<TBaseData>() where TBaseData : BaseData
        {
            return _context.GetDbSet<TBaseData>().AsQueryable();
        }

        public void Add<TBaseData>(TBaseData data) where TBaseData : BaseData
        {
            _context.AddData(data);
        }

        public void Update<TBaseData>(TBaseData data) where TBaseData : BaseData
        {
            _context.UpdateData(data);
        }

        public void Delete<TBaseData>(Guid id) where TBaseData : BaseData
        {
            var data = _context.GetDbSet<TBaseData>().Find(id);

            if (data != null)
            {
                _context.DeleteData(data);
            }
        }
    }
}
