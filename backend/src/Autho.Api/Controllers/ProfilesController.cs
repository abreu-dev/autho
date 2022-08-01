using Autho.Api.Filters;
using Autho.Application.Contracts;
using Autho.Application.Interfaces;
using Autho.Core.Enums;
using Autho.Domain.Core.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Autho.Api.Controllers
{
    public class ProfilesController : BaseController
    {
        private readonly IProfileAppService _profileAppService;
        private readonly IProfileAppQuery _profileAppQuery;

        public ProfilesController(IProfileAppService profileAppService,
                                  IProfileAppQuery profileAppQuery)
        {
            _profileAppService = profileAppService;
            _profileAppQuery = profileAppQuery;
        }

        [HttpGet, Route("api/profiles"), AuthorizationRequirement(Permission.PermissionProfileView)]
        public IActionResult Get()
        {
            return Ok(_profileAppQuery.GetAll());
        }

        [HttpPost, Route("api/profiles"), AuthorizationRequirement(Permission.PermissionProfileInsert)]
        public IActionResult Post([FromBody] ProfileCreationDto creationDto)
        {
            var result = _profileAppService.Add(creationDto);

            if (result.Type == ResultType.Failure)
            {
                return BadRequest(new
                {
                    result.Errors
                });
            }

            return NoContent();
        }

        [HttpPut, Route("api/profiles/{id}"), AuthorizationRequirement(Permission.PermissionProfileUpdate)]
        public IActionResult Put([FromRoute] Guid id, [FromBody] ProfileCreationDto creationDto)
        {
            var result = _profileAppService.Update(id, creationDto);

            if (result.Type == ResultType.Failure)
            {
                return BadRequest(new
                {
                    result.Errors
                });
            }

            return NoContent();
        }

        [HttpDelete, Route("api/profiles/{id}"), AuthorizationRequirement(Permission.PermissionProfileDelete)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var result = _profileAppService.Remove(id);

            if (result.Type == ResultType.Failure)
            {
                return BadRequest(new
                {
                    result.Errors
                });
            }

            return NoContent();
        }
    }
}
