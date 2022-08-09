namespace Autho.Application.Contracts.User
{
    public class UserCreationDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public IEnumerable<UserProfileCreationDto> Profiles { get; set; }
    }
}
