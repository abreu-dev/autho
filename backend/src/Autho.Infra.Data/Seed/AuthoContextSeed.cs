using Autho.Infra.Data.Context;
using Autho.Infra.Data.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Autho.Infra.Data.Seed
{
    public static class AuthoContextSeed
    {
        public static void SeedData(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<IAuthoContext>();

                PermissionSeed.SeedData(new GenericRepository(context));
                ProfileSeed.SeedData(new GenericRepository(context));
                UserSeed.SeedData(new GenericRepository(context));
            }
        }
    }
}
