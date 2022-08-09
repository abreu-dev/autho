using Autho.Infra.CrossCutting.Globalization.Services.Interfaces;
using MediatR;

namespace Autho.Domain.Core.Notifications
{
    public class DomainNotification : INotification
    {
        public string Type { get; set; }
        public string Error { get; set; }
        public string Detail { get; set; }

        public DomainNotification(string type, string error, string detail)
        {
            Type = type;
            Error = error;
            Detail = detail;
        }

        public DomainNotification(IGlobalizationErrorMessage message)
        {
            Type = message.Type;
            Error = message.Error;
            Detail = message.Detail;
        }
    }
}
