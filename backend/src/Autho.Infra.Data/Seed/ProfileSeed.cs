using Autho.Infra.Data.Core.Repositories;
using Autho.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autho.Infra.Data.Seed
{
    public static class ProfileSeed
    {
        public static string AdministratorProfileName => "Administrator";

        public static void SeedData(IGenericRepository repository)
        {
            var existingProfile = repository.Query<ProfileData>()
                .Include(x => x.Permissions).ThenInclude(x => x.Permission)
                .FirstOrDefault(x => x.Name == AdministratorProfileName);
            var permissions = repository.Query<PermissionData>().ToList();

            if (existingProfile == null)
            {
                var newProfile = new ProfileData()
                {
                    Name = AdministratorProfileName,
                    Permissions = new List<ProfilePermissionData>()
                };

                foreach (var permission in permissions)
                {
                    newProfile.Permissions.Add(new ProfilePermissionData()
                    {
                        PermissionId = permission.Id
                    });
                }

                repository.Add(newProfile);
            }
            else
            {
                foreach (var permission in from permission in permissions
                                           where !existingProfile.Permissions.Any(x => x.PermissionId == permission.Id)
                                           select permission)
                {
                    existingProfile.Permissions.Add(new ProfilePermissionData()
                    {
                        PermissionId = permission.Id
                    });
                }
            }

            repository.UnitOfWork.Complete();
        }
    }
}
