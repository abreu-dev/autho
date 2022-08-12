using Autho.Domain.Entities.Integration;
using Autho.Domain.Repositories.Integration;
using Autho.Infra.CrossCutting.Integration.Engine.Steps;
using Autho.Infra.CrossCutting.Integration.Integrations.User.Interfaces;

namespace Autho.Infra.CrossCutting.Integration.Integrations.User.Steps
{
    public class FinishIntegrationUserStep : IFinishIntegrationUserStep
    {
        private readonly IIntegrationRepository _repository;

        public FinishIntegrationUserStep(IIntegrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<PipelineEnd> Execute(IntegrationDomain? data)
        {
            if (data != null)
            {
                data.Finish();
                _repository.Update(data);
                _repository.UnitOfWork.Complete();
            }

            return PipelineEnd.Instance;
        }
    }
}
