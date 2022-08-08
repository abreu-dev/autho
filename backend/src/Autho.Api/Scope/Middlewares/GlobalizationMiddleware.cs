using Autho.Core.Extensions;
using Autho.Domain.Session.Interfaces;
using System.Globalization;

namespace Autho.Api.Scope.Middlewares
{
    public class GlobalizationMiddleware
    {
        private readonly RequestDelegate _next;

        private const string DefaultLanguage = "en";

        public GlobalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var sessionAccessor = context.RequestServices.GetRequiredService<ISessionAccessor>();
            var language = sessionAccessor.User?.Language.GetEnumDisplayDescription();

            if (language == null)
            {
                language = DefaultLanguage;
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            await _next(context);
        }
    }
}
