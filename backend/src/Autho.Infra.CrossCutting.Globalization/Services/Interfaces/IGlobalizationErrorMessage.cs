namespace Autho.Infra.CrossCutting.Globalization.Services.Interfaces
{
    public interface IGlobalizationErrorMessage
    {
        string Type { get; set; }
        string Error { get; set; }
        string Detail { get; set; }
    }
}
