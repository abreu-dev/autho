using Autho.Domain.Entities.Integration;
using Autho.Infra.CrossCutting.Integration.Engine.Steps;

namespace Autho.Infra.CrossCutting.Integration.Integrations.User.Interfaces
{
    public interface IFinishIntegrationUserStep : IPipelineStep<IntegrationDomain, PipelineEnd>
    {
    }
}
