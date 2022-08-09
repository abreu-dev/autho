using Autho.Api.Scope.Filters;
using Autho.Api.Scope.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Autho.Api.Scope.Extensions
{
    public static class ControllersServiceCollectionExtensions
    {
        public static void AddAuthoControllers(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(NotificationFilter));
                options.Filters.Add(new ProducesResponseTypeAttribute(typeof(BadRequestResponse), 400));
            }).AddNewtonsoftJson();
        }
    }
}
