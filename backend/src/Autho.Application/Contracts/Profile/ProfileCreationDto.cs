namespace Autho.Application.Contracts.Profile
{
    public class ProfileCreationDto
    {
        public string Name { get; set; }
        public IEnumerable<ProfilePermissionCreationDto> Permissions { get; set; }
    }
}
