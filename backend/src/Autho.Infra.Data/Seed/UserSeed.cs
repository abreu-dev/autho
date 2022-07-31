using Autho.Infra.CrossCutting.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Autho.Principal
{
    public static class UserSeed
    {
        public static string AdministratorName => "Administrator";
        public static string AdministratorEmail => "admin@gmail.com";
        public static string AdministratorLogin => "admin";
        public static string AdministratorPassword => "admin@123";
        public static string AdministratorProfileName => "Administrator";
        public static Language AdministratorLanguage => Language.EN;

        public static void SeedData(IGenericRepository repository)
        {
            var existingUser = repository.Query<UserData>()
                .Include(x => x.Profiles)
                .ThenInclude(x => x.Profile)
                .FirstOrDefault(x => x.Name == AdministratorName);

            var adminProfile = repository.Query<ProfileData>()
                .First(x => x.Name == AdministratorProfileName);

            if (existingUser == null)
            {
                var newUser = new UserData()
                {
                    Name = AdministratorName,
                    Email = AdministratorEmail,
                    Login = AdministratorLogin,
                    Password = AdministratorPassword,
                    Language = AdministratorLanguage,
                    Profiles = new List<UserProfileData>()
                    {
                        new UserProfileData()
                        {
                            ProfileId = adminProfile.Id
                        }
                    }
                };

                repository.Add(newUser);
            }
            else
            {
                if (!existingUser.Profiles.Any(x => x.Profile.Name == AdministratorProfileName))
                {
                    existingUser.Profiles = new List<UserProfileData>()
                    {
                        new UserProfileData()
                        {
                            ProfileId = adminProfile.Id
                        }
                    };
                }
            }

            repository.UnitOfWork.Complete();
        }
    }
}
