namespace Autho.Infra.CrossCutting.Integration.Engine.Pipeline.Interfaces
{
    public interface IPipelineJob
    {
        Task<PipelineJobFinish> Execute();
    }
}
