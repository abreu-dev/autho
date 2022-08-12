using Autho.Domain.Entities.Integration;
using Autho.Infra.CrossCutting.Integration.Engine;
using Autho.Infra.CrossCutting.Integration.Engine.Steps.Interfaces;

namespace Autho.Infra.CrossCutting.Integration.Integrations.User.Steps.Interfaces
{
    public interface IStartIntegrationUserStep : IPipelineJobStep<PipelineJobStart, IntegrationDomain>
    {
    }
}
