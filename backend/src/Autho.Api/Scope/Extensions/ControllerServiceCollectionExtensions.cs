using Autho.Api.Scope.Filters;

namespace Autho.Api.Scope.Extensions
{
    public static class ControllerServiceCollectionExtensions
    {
        public static void AddAuthoController(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(NotificationFilter));
            }).AddNewtonsoftJson();
        }
    }
}
