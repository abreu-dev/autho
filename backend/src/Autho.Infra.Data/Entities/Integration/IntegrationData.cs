using Autho.Core.Enums;
using Autho.Infra.Data.Core.Entities;

namespace Autho.Infra.Data.Entities.Integration
{
    public class IntegrationData : BaseData
    {
        public static string TableName => "Integration";

        public IntegrationStatus Status { get; set; }
        public DateTime? StartDateImport { get; set; }
        public DateTime? EndDateImport { get; set; }

        public virtual ICollection<IntegrationUserData> Users { get; set; }
    }
}
