using Autho.Api.Scope.Filters;
using Autho.Application.Contracts.User;
using Autho.Application.Contracts.User.Login;
using Autho.Application.Queries.Interfaces;
using Autho.Application.Queries.Parameters;
using Autho.Application.Services.Interfaces;
using Autho.Core.Enums;
using Autho.Core.Extensions;
using Autho.Domain.Core.Data.Pagination.Interfaces;
using Autho.Domain.Core.Validations;
using Autho.Domain.Core.Validations.Interfaces;
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

        /// <summary>
        /// Obtain a list of users
        /// </summary>
        [HttpGet]
        [Route("api/users")]
        [AuthorizationRequirement(Permission.UserView)]
        [ProducesResponseType(200, Type = typeof(IPagedList<UserDto>))]
        public IActionResult Get([FromQuery] UserParameters parameters)
        {
            return Ok(_userAppQuery.GetPaged(parameters));
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <response code="204">If request was successfully processed</response>
        [HttpPost]
        [Route("api/users")]
        [AuthorizationRequirement(Permission.UserInsert)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Post([FromBody] UserCreationDto creationDto)
        {
            await _userAppService.Add(creationDto);
            return NoContent();
        }

        /// <summary>
        /// Update a user by id
        /// </summary>
        /// <response code="204">If request was successfully processed</response>
        [HttpPut]
        [Route("api/users/{id}")]
        [AuthorizationRequirement(Permission.UserUpdate)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UserCreationDto creationDto)
        {
            await _userAppService.Update(id, creationDto);
            return NoContent();
        }

        /// <summary>
        /// Delete a user by id
        /// </summary>
        /// <response code="204">If request was successfully processed</response>
        [HttpDelete]
        [Route("api/users/{id}")]
        [AuthorizationRequirement(Permission.UserDelete)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _userAppService.Remove(id);
            return NoContent();
        }

        /// <summary>
        /// Login into system by login and password
        /// </summary>
        /// <response code="200">If login succeed</response>
        /// <response code="400">If login failed</response>
        [HttpPost]
        [Route("api/users/login")]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(LoginResultDto))]
        [ProducesResponseType(400, Type = typeof(ICollection<IResultError>))]
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

            return Ok(new LoginResultDto()
            {
                Token = _tokenAppService.GenerateAuthenticationToken(result.Item),
                User = new LoginResultUserDto()
                {
                    Id = result.Item.Id,
                    Name = result.Item.Name,
                    Email = result.Item.Email,
                    Login = result.Item.Login,
                    Language = result.Item.Language.GetEnumDisplayDescription() ?? string.Empty
                }
            });
        }
    }
}
