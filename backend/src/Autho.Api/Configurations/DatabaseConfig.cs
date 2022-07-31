using Autho.Principal;
using Microsoft.EntityFrameworkCore;

namespace Autho.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            services.AddDbContext<AuthoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
