using Autho.Infra.CrossCutting.Globalization.Services.Interfaces;

namespace Autho.Infra.CrossCutting.Globalization.Services
{
    public class GlobalizationErrorMessage : IGlobalizationErrorMessage
    {
        public string Type { get; set; }
        public string Error { get; set; }
        public string Detail { get; set; }

        public GlobalizationErrorMessage(string type, string error, string detail)
        {
            Type = type;
            Error = error;
            Detail = detail;
        }
    }
}
