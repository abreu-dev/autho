using Autho.Application.Contracts.Profile;

namespace Autho.Application.Contracts.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Language { get; set; }
        public IEnumerable<ProfileDto> Profiles { get; set; }
    }
}
