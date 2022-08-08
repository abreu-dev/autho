using Autho.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Autho.Api.Scope.Extensions
{
    public static class DbContextServiceCollectionExtensions
    {
        public static void AddAuthoDbContext(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            services.AddDbContext<AuthoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
