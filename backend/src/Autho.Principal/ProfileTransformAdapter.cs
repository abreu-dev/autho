namespace Autho.Principal
{
    public class ProfileTransformAdapter : TransformAdapter<ProfileDomain, ProfileData>, IProfileTransformAdapter
    {
        private readonly IPermissionTransformAdapter _permissionAdapter;

        public ProfileTransformAdapter(IPermissionTransformAdapter permissionAdapter)
        {
            _permissionAdapter = permissionAdapter;
        }

        public override ProfileDomain Transform(ProfileData data)
        {
            var permissions = data.Permissions == null ? new List<PermissionDomain>()
                : _permissionAdapter.Transform(data.Permissions.Select(x => x.Permission)).ToList();

            return new ProfileDomain(data.Id, data.Name, permissions);
        }

        public override ProfileData Transform(ProfileDomain domain)
        {
            var permissions = domain.Permissions == null ? new List<PermissionData>()
                : _permissionAdapter.Transform(domain.Permissions).ToList();

            return new ProfileData()
            {
                Id = domain.Id,
                Name = domain.Name,
                Permissions = permissions.Select(permission => new ProfilePermissionData()
                {
                    PermissionId = permission.Id
                }).ToList()
            };
        }
    }
}
