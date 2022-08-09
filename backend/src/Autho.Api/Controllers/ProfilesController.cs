using Autho.Api.Scope.Filters;
using Autho.Application.Contracts;
using Autho.Application.Queries.Interfaces;
using Autho.Application.Queries.Parameters;
using Autho.Application.Services.Interfaces;
using Autho.Core.Enums;
using Autho.Domain.Core.Data.Pagination.Interfaces;
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

        /// <summary>
        /// Obtain a list of profiles
        /// </summary>
        [HttpGet]
        [Route("api/profiles")]
        [AuthorizationRequirement(Permission.ProfileView)]
        [ProducesResponseType(200, Type = typeof(IPagedList<ProfileDto>))]
        public IActionResult Get([FromQuery] ProfileParameters parameters)
        {
            return Ok(_profileAppQuery.GetPaged(parameters));
        }

        /// <summary>
        /// Add a new profile
        /// </summary>
        /// <response code="204">If request was successfully processed</response>
        [HttpPost]
        [Route("api/profiles")]
        [AuthorizationRequirement(Permission.ProfileInsert)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Post([FromBody] ProfileCreationDto creationDto)
        {
            await _profileAppService.Add(creationDto);
            return NoContent();
        }

        /// <summary>
        /// Update a profile by id
        /// </summary>
        /// <response code="204">If request was successfully processed</response>
        [HttpPut]
        [Route("api/profiles/{id}")]
        [AuthorizationRequirement(Permission.ProfileUpdate)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] ProfileCreationDto creationDto)
        {
            await _profileAppService.Update(id, creationDto);
            return NoContent();
        }

        /// <summary>
        /// Delete a profile by id
        /// </summary>
        /// <response code="204">If request was successfully processed</response>
        [HttpDelete]
        [Route("api/profiles/{id}")]
        [AuthorizationRequirement(Permission.ProfileDelete)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _profileAppService.Remove(id);
            return NoContent();
        }
    }
}
