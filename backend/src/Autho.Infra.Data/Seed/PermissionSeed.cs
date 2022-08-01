using Autho.Core.Enums;
using Autho.Core.Extensions;
using Autho.Infra.Data.Core.Repositories;
using Autho.Infra.Data.Entities;

namespace Autho.Infra.Data.Seed
{
    public static class PermissionSeed
    {
        public static void SeedData(IGenericRepository repository)
        {
            var existingPermissions = repository.Query<PermissionData>().ToList();

            foreach (var item in Enum.GetValues(typeof(Permission)))
            {
                var itemEnum = (Permission)item;

                var name = itemEnum.GetEnumDisplayName();
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentNullException(name);
                }

                var code = itemEnum.GetEnumDisplayDescription();
                if (string.IsNullOrEmpty(code))
                {
                    throw new ArgumentNullException(name);
                }

                if (!existingPermissions.Any(x => x.Code == code))
                {
                    var newPermission = new PermissionData()
                    {
                        Name = name,
                        Code = code
                    };
                    repository.Add(newPermission);
                }
            }

            repository.UnitOfWork.Complete();
        }
    }
}
