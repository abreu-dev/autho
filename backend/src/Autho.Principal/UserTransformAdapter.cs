namespace Autho.Principal
{
    public class UserTransformAdapter : TransformAdapter<UserDomain, UserData>, IUserTransformAdapter
    {
        private readonly IProfileTransformAdapter _profileAdapter;

        public UserTransformAdapter(IProfileTransformAdapter profileAdapter)
        {
            _profileAdapter = profileAdapter;
        }

        public override UserDomain Transform(UserData data)
        {
            var profiles = data.Profiles == null ? new List<ProfileDomain>()
                : _profileAdapter.Transform(data.Profiles.Select(x => x.Profile)).ToList();

            return new UserDomain(data.Id, data.Name, data.Email, data.Login, data.Password, profiles);
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
                Profiles = profiles.Select(profile => new UserProfileData()
                {
                    ProfileId = profile.Id
                }).ToList()
            };
        }
    }
}
