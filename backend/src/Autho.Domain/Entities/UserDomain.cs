using Autho.Domain.Core.Entities;
using Autho.Infra.CrossCutting.Globalization;

namespace Autho.Domain.Entities
{
    public class UserDomain : BaseDomain
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public Language Language { get; private set; }

        public virtual ICollection<ProfileDomain> Profiles { get; private set; }

        public UserDomain(Guid id, string name, string email, string login, string password, Language language, ICollection<ProfileDomain> profiles) : base(id)
        {
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            Profiles = profiles;
            Language = language;
        }
    }
}
