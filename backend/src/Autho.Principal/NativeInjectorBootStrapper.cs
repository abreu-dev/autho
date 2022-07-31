using Microsoft.Extensions.DependencyInjection;

namespace Autho.Principal
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application - Services
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenService, TokenService>();

            // Application - AppServices
            services.AddScoped<IProfileAppService, ProfileAppService>();

            // Application - AppQueries
            services.AddScoped<IProfileAppQuery, ProfileAppQuery>();

            // Infra - Data - Contexts
            services.AddScoped<IAuthoContext, AuthoContext>();
            services.AddScoped<AuthoContext>();

            // Infra - Data - Adapters
            services.AddScoped<IPermissionTransformAdapter, PermissionTransformAdapter>();
            services.AddScoped<IProfileTransformAdapter, ProfileTransformAdapter>();
            services.AddScoped<IUserTransformAdapter, UserTransformAdapter>();

            // Infra - Data - Repositories
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGenericRepository, GenericRepository>();
        }
    }
}
