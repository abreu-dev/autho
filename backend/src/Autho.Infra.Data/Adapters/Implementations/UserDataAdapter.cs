using Autho.Domain.Entities;
using Autho.Infra.Data.Adapters.Interfaces;
using Autho.Infra.Data.Core.Adapter;
using Autho.Infra.Data.Entities;

namespace Autho.Infra.Data.Adapters.Implementations
{
    public class UserDataAdapter : DataAdapter<UserDomain, UserData>, IUserDataAdapter
    {
        private readonly IProfileDataAdapter _profileAdapter;

        public UserDataAdapter(IProfileDataAdapter profileAdapter)
        {
            _profileAdapter = profileAdapter;
        }

        public override UserDomain Transform(UserData data)
        {
            var profiles = data.Profiles == null ? new List<ProfileDomain>()
                : _profileAdapter.Transform(data.Profiles.Select(x => x.Profile)).ToList();

            return new UserDomain(data.Id, data.Name, data.Email, data.Login, data.Password, data.Language, profiles);
        }

        public override UserData Transform(UserDomain domain)
        {
            var profiles = domain.Profiles == null ? new List<ProfileData>()
                : _profileAdapter.Transform(domain.Profiles).ToList();

            return new UserData()
            {
                Id = domain.Id,
                Name = domain.Name,
                Email = domain.Email,
                Login = domain.Login,
                Password = domain.Password,
                Language = domain.Language,
                Profiles = profiles.Select(profile => new UserProfileData()
                {
                    ProfileId = profile.Id
                }).ToList()
            };
        }
    }
}
