namespace Autho.Application.Contracts
{
    public class LoginResultDto
    {
        public string Token { get; set; }
        public LoginResultUserDto User { get; set; }
    }
}
