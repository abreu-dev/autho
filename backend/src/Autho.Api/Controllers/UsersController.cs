using Autho.Application.Contracts;
using Autho.Application.Interfaces;
using Autho.Core.Extensions;
using Autho.Domain.Core.Notifications;
using Autho.Domain.Core.Validation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autho.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;

        public UsersController(INotificationHandler<DomainNotification> notifications, 
                               IAuthenticationService authenticationService,
                               ITokenService tokenService) : base(notifications)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
        }

        [HttpPost, Route("api/users/login"), AllowAnonymous]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var result = _authenticationService.Authenticate(loginDto.Login, loginDto.Password);

            if (result.Type == ResultType.Failure || result.Item == null)
            {
                return BadRequest(new
                {
                    result.Errors
                });
            }

            return Ok(new
            {
                user = new LoginResultDto()
                {
                    Token = _tokenService.GenerateAuthenticationToken(result.Item),
                    User = new UserDto()
                    {
                        Id = result.Item.Id,
                        Name = result.Item.Name,
                        Email = result.Item.Email,
                        Login = result.Item.Login,
                        Language = result.Item.Language.GetEnumDisplayDescription() ?? ""
                    }
                }
            });
        }
    }
}
