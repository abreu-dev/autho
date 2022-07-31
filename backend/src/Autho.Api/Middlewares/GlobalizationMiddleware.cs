using Autho.Principal;
using System.Globalization;

namespace Autho.Api
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
            var user = (UserDomain?)context.Items["User"];
            var language = user?.Language.GetEnumDisplayDescription();

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
