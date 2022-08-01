using Autho.Application.Interfaces;
using Autho.Application.Services;
using Autho.Domain.Repositories;
using Autho.Infra.Data.Adapters.Implementations;
using Autho.Infra.Data.Adapters.Interfaces;
using Autho.Infra.Data.Context;
using Autho.Infra.Data.Core.Context;
using Autho.Infra.Data.Core.Repositories;
using Autho.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Autho.Infra.CrossCutting.IoC
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
            services.AddScoped<IBaseContext, AuthoContext>();
            services.AddScoped<AuthoContext>();

            // Infra - Data - Adapters
            services.AddScoped<IPermissionDataAdapter, PermissionDataAdapter>();
            services.AddScoped<IProfileDataAdapter, ProfileDataAdapter>();
            services.AddScoped<IUserDataAdapter, UserDataAdapter>();

            // Infra - Data - Repositories
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGenericRepository, GenericRepository>();
        }
    }
}
