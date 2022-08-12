using Autho.Domain.Entities.Integration;
using Autho.Domain.Repositories.Integration;
using Autho.Infra.CrossCutting.Integration.Engine;
using Autho.Infra.CrossCutting.Integration.Integrations.User.Steps.Interfaces;

namespace Autho.Infra.CrossCutting.Integration.Integrations.User.Steps
{
    public class FinishIntegrationUserStep : IFinishIntegrationUserStep
    {
        private readonly IIntegrationRepository _repository;

        public FinishIntegrationUserStep(IIntegrationRepository repository)
        {
            _repository = repository;
        }

        public Task<PipelineJobFinish> Execute(IntegrationDomain? data)
        {
            if (data != null)
            {
                data.Finish();
                _repository.Update(data);
                _repository.UnitOfWork.Complete();
            }

            return Task.FromResult(PipelineJobFinish.Instance);
        }
    }
}
