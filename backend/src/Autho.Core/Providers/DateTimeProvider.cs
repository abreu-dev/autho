using Autho.Core.Providers.Interfaces;

namespace Autho.Core.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
