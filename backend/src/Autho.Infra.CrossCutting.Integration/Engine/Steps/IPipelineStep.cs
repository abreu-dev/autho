namespace Autho.Infra.CrossCutting.Integration.Engine.Steps
{
    public interface IPipelineStep<TIn, TOut>
    {
        Task<TOut?> Execute(TIn? data);
    }
}
