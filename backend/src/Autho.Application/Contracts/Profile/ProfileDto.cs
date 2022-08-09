using Autho.Application.Contracts.Permission;

namespace Autho.Application.Contracts.Profile
{
    public class ProfileDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PermissionDto> Permissions { get; set; }
    }
}
