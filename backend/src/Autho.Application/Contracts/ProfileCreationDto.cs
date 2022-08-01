namespace Autho.Application.Contracts
{
    public class ProfileCreationDto
    {
        public string Name { get; set; }
        public IEnumerable<ProfilePermissionCreationDto> Permissions { get; set; }
    }
}
