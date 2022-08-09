using Autho.Infra.Data.Core.Entities;

namespace Autho.Infra.Data.Entities.Integration
{
    public class IntegrationUserData : BaseData
    {
        public static string TableName => "IntegrationUser";

        public Guid IntegrationId { get; set; }
        public virtual IntegrationData Integration { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Language { get; set; }
    }
}
