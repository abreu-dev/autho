namespace Autho.Api.Scope.Responses
{
    public class BadRequestResponseError
    {
        public string Type { get; set; }
        public string Error { get; set; }
        public string Detail { get; set; }

        public BadRequestResponseError(string type, string error, string detail)
        {
            Type = type;
            Error = error;
            Detail = detail;
        }
    }
}
