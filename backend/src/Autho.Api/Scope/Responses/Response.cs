using System.Diagnostics;

namespace Autho.Api.Scope.Responses
{
    public class Response
    {
        public string? Instance { get; set; }
        public string TraceId { get; set; }
        public List<ResponseError> Errors { get; set; }

        public Response(string? instance)
        {
            Instance = instance;
            TraceId = Activity.Current?.TraceId.ToString() ?? "";
            Errors = new List<ResponseError>();
        }

        public bool IsValid()
        {
            return Errors.Count == 0;
        }
    }
}
