using Autho.Api.Scope.Filters;
using Autho.Application.Contracts;
using Autho.Application.Queries.Interfaces;
using Autho.Application.Queries.Parameters;
using Autho.Application.Services.Interfaces;
using Autho.Core.Enums;
using Autho.Core.Extensions;
using Autho.Domain.Core.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autho.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserAppQuery _userAppQuery;
        private readonly IUserAppService _userAppService;
        private readonly IAuthenticationAppService _authenticationAppService;
        private readonly ITokenAppService _tokenAppService;

        public UsersController(IAuthenticationAppService authenticationAppService,
                               ITokenAppService tokenAppService,
                               IUserAppQuery userAppQuery,
                               IUserAppService userAppService)
        {
            _authenticationAppService = authenticationAppService;
            _tokenAppService = tokenAppService;
            _userAppQuery = userAppQuery;
            _userAppService = userAppService;
        }

        [HttpGet, Route("api/users"), AuthorizationRequirement(Permission.UserView)]
        public IActionResult Get([FromQuery] UserParameters parameters)
        {
            return Ok(_userAppQuery.GetPaged(parameters));
        }

        [HttpPost, Route("api/users"), AuthorizationRequirement(Permission.UserInsert)]
        public async Task<IActionResult> Post([FromBody] UserCreationDto creationDto)
        {
            await _userAppService.Add(creationDto);

            return CustomResponse("api/users");
        }

        [HttpPut, Route("api/users/{id}"), AuthorizationRequirement(Permission.UserUpdate)]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UserCreationDto creationDto)
        {
            await _userAppService.Update(id, creationDto);

            return CustomResponse("api/users", id);
        }

        [HttpDelete, Route("api/users/{id}"), AuthorizationRequirement(Permission.UserDelete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _userAppService.Remove(id);

            return CustomResponse("api/users", id);
        }

        [HttpPost, Route("api/users/login"), AllowAnonymous]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var result = _authenticationAppService.Authenticate(loginDto.Login, loginDto.Password);

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
                    Token = _tokenAppService.GenerateAuthenticationToken(result.Item),
                    User = new LoginResultUserDto()
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
