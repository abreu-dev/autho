using Autho.Domain.Entities.Integration;
using Autho.Domain.Repositories.Integration;
using Autho.Infra.CrossCutting.Integration.Engine;
using Autho.Infra.CrossCutting.Integration.Integrations.User.Steps.Interfaces;

namespace Autho.Infra.CrossCutting.Integration.Integrations.User.Steps
{
    public class StartIntegrationUserStep : IStartIntegrationUserStep
    {
        private readonly IIntegrationRepository _repository;

        public StartIntegrationUserStep(IIntegrationRepository repository)
        {
            _repository = repository;
        }

        public Task<IntegrationDomain?> Execute(PipelineJobStart data)
        {
            var integration = _repository.FirstPendingIntegrationUser();

            if (integration != null)
            {
                integration.Start();
            }

            return Task.FromResult(integration);
        }
    }
}
