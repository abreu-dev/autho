using Autho.Domain.Entities.Integration;
using Autho.Infra.Data.Adapters.Integration.Interfaces;
using Autho.Infra.Data.Core.Adapter;
using Autho.Infra.Data.Entities.Integration;

namespace Autho.Infra.Data.Adapters.Integration
{
    public class IntegrationUserDataAdapter : DataAdapter<IntegrationUserDomain, IntegrationUserData>,
        IIntegrationUserDataAdapter

    {
        public override IntegrationUserDomain Transform(IntegrationUserData data)
        {
            return new IntegrationUserDomain(data.Id, data.IntegrationId, data.Name, data.Email, data.Login, data.Password, data.Language);
        }

        public override IntegrationUserData Transform(IntegrationUserDomain domain)
        {
            return new IntegrationUserData()
            {
                Id = domain.Id,
                IntegrationId = domain.IntegrationId,
                Name = domain.Name,
                Email = domain.Email,
                Login = domain.Login,
                Password = domain.Password,
                Language = domain.Language
            };
        }
    }
}
