using Autho.Application.Services.Interfaces;
using Autho.Core.Providers.Interfaces;
using Autho.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Autho.Application.Services
{
    public class TokenAppService : ITokenAppService
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly AppSettings _appSettings;

        public TokenAppService(IDateTimeProvider dateTimeProvider,
                            IOptions<AppSettings> appSettings)
        {
            _dateTimeProvider = dateTimeProvider;
            _appSettings = appSettings.Value;
        }

        public string GenerateAuthenticationToken(UserDomain user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString())
                }),
                Expires = _dateTimeProvider.UtcNow.AddHours(_appSettings.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
