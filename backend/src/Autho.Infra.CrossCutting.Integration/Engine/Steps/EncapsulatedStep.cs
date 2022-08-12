using Autho.Infra.CrossCutting.Integration.Engine.Steps.Interfaces;

namespace Autho.Infra.CrossCutting.Integration.Engine.Steps
{
    public class EncapsulatedStep<TIn, TOut, TOutNext> : IPipelineJobStep<TIn, TOutNext>
    {
        private readonly IPipelineJobStep<TIn, TOut> _actualStep;
        private readonly IPipelineJobStep<TOut, TOutNext> _nextStep;

        public EncapsulatedStep(IPipelineJobStep<TIn, TOut> actualStep, IPipelineJobStep<TOut, TOutNext> nextStep)
        {
            _actualStep = actualStep;
            _nextStep = nextStep;
        }

        public async Task<TOutNext?> Execute(TIn? data)
        {
            var actualStepData = await _actualStep.Execute(data);
            return await _nextStep.Execute(actualStepData);
        }
    }
}
