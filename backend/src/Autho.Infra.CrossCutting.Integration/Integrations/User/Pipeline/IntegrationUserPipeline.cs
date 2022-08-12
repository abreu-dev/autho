using Autho.Infra.CrossCutting.Integration.Engine.Steps;
using Autho.Infra.CrossCutting.Integration.Integrations.User.Interfaces;

namespace Autho.Infra.CrossCutting.Integration.Integrations.User.Pipeline
{
    public class IntegrationUserPipeline : IIntegrationUserPipeline
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

        public async Task Execute()
        {
            var startStepResult = await _startStep.Execute(PipelineStart.Instance);
            var processStepResult = await _processStep.Execute(startStepResult);
            await _finishStep.Execute(processStepResult);
        }
    }
}
