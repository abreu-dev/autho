namespace Autho.Application.Contracts
{
    public class LoginResultUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Language { get; set; }
    }
}
