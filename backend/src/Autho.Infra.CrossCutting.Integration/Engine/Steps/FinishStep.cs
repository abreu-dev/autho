using Autho.Infra.CrossCutting.Integration.Engine.Steps.Interfaces;

namespace Autho.Infra.CrossCutting.Integration.Engine.Steps
{
    public class FinishStep<TIn> : IPipelineJobStep<TIn, PipelineJobFinish>
    {
        public Task<PipelineJobFinish> Execute(TIn? data)
        {
            return Task.FromResult(PipelineJobFinish.Instance);
        }
    }
}
