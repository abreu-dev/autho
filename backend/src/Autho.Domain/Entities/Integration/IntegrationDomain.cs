using Autho.Core.Enums;
using Autho.Domain.Core.Entities;

namespace Autho.Domain.Entities.Integration
{
    public class IntegrationDomain : BaseDomain
    {
        public IntegrationStatus Status { get; set; }
        public DateTime? StartDateImport { get; set; }
        public DateTime? EndDateImport { get; set; }

        public virtual ICollection<IntegrationUserDomain> Users { get; set; }

        public IntegrationDomain(Guid id, ICollection<IntegrationUserDomain> users) : base(id)
        {
            Users = users;
            Status = IntegrationStatus.None;
        }

        public void Start()
        {
            StartDateImport = DateTime.UtcNow;
            Status = IntegrationStatus.Started;
        }

        public void Finish()
        {
            EndDateImport = DateTime.UtcNow;
            Status = IntegrationStatus.Finished;
        }
    }
}
