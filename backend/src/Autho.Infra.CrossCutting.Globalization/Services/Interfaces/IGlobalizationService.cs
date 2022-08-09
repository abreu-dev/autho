namespace Autho.Infra.CrossCutting.Globalization.Services.Interfaces
{
    public interface IGlobalizationService
    {
        string LoginFailed { get; }
        string DatabaseUnavailable { get; }
        string NotFound { get; }
        string Profile { get; }
        string UniqueValue { get; }
        string Name { get; }
        string User { get; }
        string Email { get; }
        string Login { get; }
        string MissingValue { get; }
        string Password { get; }

        IGlobalizationErrorMessage ErrorMessage(string type);
        IGlobalizationErrorMessage ErrorMessage(string type, params string[] args);
    }
}
