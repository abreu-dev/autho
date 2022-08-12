using Autho.Infra.CrossCutting.Integration.Engine.Steps;
using Autho.Infra.CrossCutting.Integration.Engine.Steps.Interfaces;

namespace Autho.Infra.CrossCutting.Integration.Engine.Builder
{
    public class PipelineJobInternalBuilder<TIn, TOut>
    {
        private readonly IPipelineJobStep<TIn, TOut> _step;

        public PipelineJobInternalBuilder(IPipelineJobStep<TIn, TOut> step)
        {
            _step = step;
        }

        public PipelineJobInternalBuilder<TIn, TOutNext> WithStep<TOutNext>(IPipelineJobStep<TOut, TOutNext> nextStep)
        {
            var encapsulatedSteps = new EncapsulatedStep<TIn, TOut, TOutNext>(_step, nextStep);
            return new PipelineJobInternalBuilder<TIn, TOutNext>(encapsulatedSteps);
        }

        public IPipelineJobStep<TIn, PipelineJobFinish> Build()
        {
            return new EncapsulatedStep<TIn, TOut, PipelineJobFinish>(_step, new FinishStep<TOut>());
        }
    }
}
