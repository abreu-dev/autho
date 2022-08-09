using Autho.Domain.Core.Entities;

namespace Autho.Domain.Entities.Integration
{
    public class IntegrationUserDomain : BaseDomain
    {
        public Guid IntegrationId { get; private set; }
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public string? Login { get; private set; }
        public string? Password { get; private set; }
        public string? Language { get; private set; }

        public IntegrationUserDomain(Guid integrationId, string? name, string? email, string? login, string? password, string? language)
        {
            IntegrationId = integrationId;
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            Language = language;
        }

        public IntegrationUserDomain(Guid id, Guid integrationId, string? name, string? email, string? login, string? password, string? language) : base(id)
        {
            IntegrationId = integrationId;
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            Language = language;
        }
    }
}
