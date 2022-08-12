using Autho.Infra.CrossCutting.Integration.Integrations.User.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Autho.Infra.CrossCutting.Integration.IoC
{
    public static class IntegrationBootStrapper
    {
        public static void Load(IServiceCollection services)
        {
            IntegrationUserBootStrapper.Load(services);
        }
    }
}
