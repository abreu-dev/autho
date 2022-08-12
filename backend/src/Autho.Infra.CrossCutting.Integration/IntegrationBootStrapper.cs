using Autho.Infra.CrossCutting.Integration.Integrations.User.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Autho.Infra.CrossCutting.Integration
{
    public static class IntegrationBootStrapper
    {
        public static void Load(IServiceCollection services)
        {
            services.Load();
        }
    }
}
