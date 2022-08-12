using Autho.Infra.CrossCutting.Integration.Engine;
using Autho.Infra.CrossCutting.Integration.Engine.Builder;
using Autho.Infra.CrossCutting.Integration.Engine.Pipeline;
using Autho.Infra.CrossCutting.Integration.Engine.Steps.Interfaces;
using Autho.Infra.CrossCutting.Integration.Integrations.User.Pipeline.Interfaces;
using Autho.Infra.CrossCutting.Integration.Integrations.User.Steps.Interfaces;

namespace Autho.Infra.CrossCutting.Integration.Integrations.User.Pipeline
{
    public class IntegrationUserPipeline : PipelineJob, IIntegrationUserPipeline
    {
        private readonly IStartIntegrationUserStep _startStep;
        private readonly IProcessIntegrationUserStep _processStep;
        private readonly IFinishIntegrationUserStep _finishStep;

        public IntegrationUserPipeline(
            IStartIntegrationUserStep startStep,
            IProcessIntegrationUserStep processStep,
            IFinishIntegrationUserStep finishStep)
        {
            _startStep = startStep;
            _processStep = processStep;
            _finishStep = finishStep;
        }

        protected override IPipelineJobStep<PipelineJobStart, PipelineJobFinish> Build()
        {
            return new PipelineJobBuilder()
                .WithStep(_startStep)
                .WithStep(_processStep)
                .WithStep(_finishStep)
                .Build();
        }
    }
}
