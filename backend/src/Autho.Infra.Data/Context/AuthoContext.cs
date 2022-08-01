using Autho.Infra.Data.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Autho.Infra.Data.Context
{
    public class AuthoContext : DbContext, IAuthoContext
    {
        public AuthoContext(DbContextOptions<AuthoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
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
            Add(data);
        }

        public void UpdateData<TBaseData>(TBaseData data) where TBaseData : BaseData
        {
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
            data.OnUpdate();

            var entry = GetDbEntry(data);

            if (entry != null)
            {
                entry.Property(x => x.CreatedBy).IsModified = false;
                entry.Property(x => x.CreatedDate).IsModified = false;
            }
        }
    }
}
