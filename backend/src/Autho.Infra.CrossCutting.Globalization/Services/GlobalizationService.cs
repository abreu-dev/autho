using Autho.Infra.CrossCutting.Globalization.Resources;
using Autho.Infra.CrossCutting.Globalization.Services.Interfaces;
using System.Text;

namespace Autho.Infra.CrossCutting.Globalization.Services
{
    public class GlobalizationService : IGlobalizationService
    {
        public string LoginFailed => "LoginFailed";
        public string DatabaseUnavailable => "DatabaseUnavailable";
        public string NotFound => "NotFound";
        public string Profile => "Profile";
        public string UniqueValue => "UniqueValue";
        public string Name => "Name";
        public string User => "User";
        public string Email => "Email";
        public string Login => "Login";
        public string MissingValue => "MissingValue";
        public string Password => "Password";

        public IGlobalizationErrorMessage ErrorMessage(string type)
        {
            var error = AuthoResource.ResourceManager.GetString(GetTypeAsError(type))
                ?? AuthoResource.MessageError;

            var detail = AuthoResource.ResourceManager.GetString(GetTypeAsDetail(type))
                ?? AuthoResource.MessageDetail;

            return new GlobalizationErrorMessage(type, error, detail);
        }

        public IGlobalizationErrorMessage ErrorMessage(string type, params string[] args)
        {
            var error = AuthoResource.ResourceManager.GetString(GetTypeAsError(type))
                ?? AuthoResource.MessageError;

            var detail = AuthoResource.ResourceManager.GetString(GetTypeAsDetail(type));

            if (detail != null)
            {
                var formatedArgs = args.Select(x => AuthoResource.ResourceManager.GetString(x)).ToArray();
                detail = string.Format(detail, formatedArgs);
            }
            else
            {
                detail = AuthoResource.MessageDetail;
            }

            return new GlobalizationErrorMessage(type, error, detail);
        }

        private string GetTypeAsError(string type)
        {
            return new StringBuilder()
                .Append(type)
                .Append("Error")
                .ToString();
        }

        private string GetTypeAsDetail(string type)
        {
            return new StringBuilder()
                .Append(type)
                .Append("Detail")
                .ToString();
        }
    }
}
