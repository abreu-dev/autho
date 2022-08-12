namespace Autho.Infra.CrossCutting.Integration.Engine.Steps.Interfaces
{
    public interface IPipelineJobStep<TIn, TOut>
    {
        Task<TOut?> Execute(TIn? data);
    }
}
