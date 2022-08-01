namespace Autho.Application.Contracts
{
    public class LoginResultDto
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
