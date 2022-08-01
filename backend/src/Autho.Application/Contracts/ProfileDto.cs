namespace Autho.Application.Contracts
{
    public class ProfileDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PermissionDto> Permissions { get; set; }
    }
}
