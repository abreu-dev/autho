using Autho.Infra.CrossCutting.Integration.Integrations.User.Pipeline;
using Autho.Infra.CrossCutting.Integration.Integrations.User.Pipeline.Interfaces;
using Autho.Infra.CrossCutting.Integration.Integrations.User.Steps;
using Autho.Infra.CrossCutting.Integration.Integrations.User.Steps.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Autho.Infra.CrossCutting.Integration.Integrations.User.IoC
{
    public static class IntegrationUserBootStrapper
    {
        public static void Load(this IServiceCollection services)
        {
            // Pipeline
            services.AddScoped<IIntegrationUserPipeline, IntegrationUserPipeline>();

            // Steps
            services.AddScoped<IStartIntegrationUserStep, StartIntegrationUserStep>();
            services.AddScoped<IProcessIntegrationUserStep, ProcessIntegrationUserStep>();
            services.AddScoped<IFinishIntegrationUserStep, FinishIntegrationUserStep>();
        }
    }
}
