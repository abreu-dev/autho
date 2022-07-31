using Microsoft.Extensions.DependencyInjection;

namespace Autho.Principal
{
    public static class AuthoContextInitializer
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
