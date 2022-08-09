namespace Autho.Application.Contracts.User.Login
{
    public class LoginResultDto
    {
        public string Token { get; set; }
        public LoginResultUserDto User { get; set; }
    }
}
