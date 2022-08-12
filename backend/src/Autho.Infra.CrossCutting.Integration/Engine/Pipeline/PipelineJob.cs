using Autho.Infra.CrossCutting.Integration.Engine.Pipeline.Interfaces;
using Autho.Infra.CrossCutting.Integration.Engine.Steps.Interfaces;

namespace Autho.Infra.CrossCutting.Integration.Engine.Pipeline
{
    public abstract class PipelineJob : IPipelineJob
    {
        public async Task<PipelineJobFinish> Execute()
        {
            return await Build().Execute(PipelineJobStart.Instance);
        }

        protected abstract IPipelineJobStep<PipelineJobStart, PipelineJobFinish> Build();
    }
}
