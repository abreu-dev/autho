using Autho.Infra.CrossCutting.IoC;

namespace Autho.Api.Scope
{
    public static class ApiBootstrapper
    {
        public static void Load(IServiceCollection services)
        {
            NativeInjectorBootStrapper.Load(services);
        }
    }
}
