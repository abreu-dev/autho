namespace Autho.Principal
{
    public class ProfileCreationDto
    {
        public string Name { get; set; }
        public IEnumerable<ProfilePermissionCreationDto> Permissions { get; set; }
    }
}
