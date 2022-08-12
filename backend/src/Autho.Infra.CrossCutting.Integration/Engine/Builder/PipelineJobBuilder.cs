using Autho.Infra.CrossCutting.Integration.Engine.Steps.Interfaces;

namespace Autho.Infra.CrossCutting.Integration.Engine.Builder
{
    public class PipelineJobBuilder
    {
        public PipelineJobInternalBuilder<TIn, TOut> WithStep<TIn, TOut>(IPipelineJobStep<TIn, TOut> step)
        {
            return new PipelineJobInternalBuilder<TIn, TOut>(step);
        }
    }
}
