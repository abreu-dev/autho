using System.Diagnostics;

namespace Autho.Api.Scope.Responses
{
    public class BadRequestResponse
    {
        public string? Instance { get; set; }
        public string? TraceId { get; set; }
        public List<BadRequestResponseError> Errors { get; set; }

        public BadRequestResponse(string? instance)
        {
            Instance = instance;
            TraceId = Activity.Current?.TraceId.ToString();
            Errors = new List<BadRequestResponseError>();
        }

        public bool IsValid()
        {
            return Errors.Count == 0;
        }
    }
}
