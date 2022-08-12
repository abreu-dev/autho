using Autho.Domain.Entities.Integration;
using Autho.Infra.Data.Adapters.Integration.Interfaces;
using Autho.Infra.Data.Core.Adapter;
using Autho.Infra.Data.Entities.Integration;

namespace Autho.Infra.Data.Adapters.Integration
{
    public class IntegrationDataAdapter : DataAdapter<IntegrationDomain, IntegrationData>,
        IIntegrationDataAdapter
    {
        private readonly IIntegrationUserDataAdapter _integrationUserDataAdapter;

        public IntegrationDataAdapter(IIntegrationUserDataAdapter integrationUserDataAdapter)
        {
            _integrationUserDataAdapter = integrationUserDataAdapter;
        }

        public override IntegrationDomain? Transform(IntegrationData? data)
        {
            if (data == null) return null;

            var users = data.Users == null ? new List<IntegrationUserDomain>()
                : _integrationUserDataAdapter.Transform(data.Users).ToList();

            return new IntegrationDomain(data.Id, users);
        }

        public override IntegrationData? Transform(IntegrationDomain? domain)
        {
            if (domain == null) return null;

            var users = domain.Users == null ? new List<IntegrationUserData>()
                : _integrationUserDataAdapter.Transform(domain.Users).ToList();

            return new IntegrationData()
            {
                Id = domain.Id,
                Status = domain.Status,
                StartDateImport = domain.StartDateImport,
                EndDateImport = domain.EndDateImport,
                Users = users
            };
        }
    }
}
