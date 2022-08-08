using Autho.Core.Providers.Interfaces;
using Autho.Domain.Session.Interfaces;
using Autho.Infra.Data.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Autho.Infra.Data.Context
{
    public class AuthoContext : DbContext, IAuthoContext
    {
        protected readonly IDateTimeProvider _dateTimeProvider;
        protected readonly ISessionAccessor _sessionAccessor;

        public AuthoContext(DbContextOptions<AuthoContext> options,
                            IDateTimeProvider dateTimeProvider,
                            ISessionAccessor sessionAccessor) : base(options)
        {
            _dateTimeProvider = dateTimeProvider;
            _sessionAccessor = sessionAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public bool IsAvailable()
        {
            return Database.CanConnect();
        }

        public DbSet<TBaseData> GetDbSet<TBaseData>() where TBaseData : BaseData
        {
            return Set<TBaseData>();
        }

        public EntityEntry<TBaseData> GetDbEntry<TBaseData>(TBaseData data) where TBaseData : BaseData
        {
            return Entry(data);
        }

        public IQueryable<TBaseData> Query<TBaseData>() where TBaseData : BaseData
        {
            return Set<TBaseData>().AsQueryable();
        }

        public void AddData<TBaseData>(TBaseData data) where TBaseData : BaseData
        {
            data.OnCreate(GetDate(), GetLogin());
            Add(data);
        }

        public void UpdateData<TBaseData>(TBaseData data) where TBaseData : BaseData
        {
            data.OnUpdate(GetDate(), GetLogin());
            Update(data);
        }

        public void DeleteData<TBaseData>(TBaseData data) where TBaseData : BaseData
        {
            Remove(data);
        }

        public void Complete()
        {
            SaveChanges();
        }

        public void UpdateState<TBaseData>(TBaseData data) where TBaseData : BaseData
        {
            var entry = GetDbEntry(data);
            data.OnUpdate(GetDate(), GetLogin());

            if (entry != null)
            {
                entry.Property(x => x.CreatedBy).IsModified = false;
                entry.Property(x => x.CreatedDate).IsModified = false;
            }
        }

        private string GetLogin() => _sessionAccessor.User?.Login ?? "System";
        private DateTime GetDate() => _dateTimeProvider.UtcNow;
    }
}
