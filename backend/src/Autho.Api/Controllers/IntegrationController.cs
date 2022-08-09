using Autho.Api.Scope.Filters;
using Autho.Application.Contracts.Integration;
using Autho.Application.Services.Integration.Interfaces;
using Autho.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Autho.Api.Controllers
{
    public class IntegrationController : BaseController
    {
        private readonly IIntegrationAppService _integrationAppService;

        public IntegrationController(IIntegrationAppService integrationAppService)
        {
            _integrationAppService = integrationAppService;
        }

        /// <summary>
        /// Add a list of users
        /// </summary>
        /// <response code="201">If request was successfully created</response>
        [HttpPost]
        [Route("api/integration/users")]
        [AuthorizationRequirement(Permission.UserIntegrationInsert)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Post([FromBody] IEnumerable<IntegrationUserDto> integrationDtos)
        {
            var integrationId = Guid.NewGuid();
            await _integrationAppService.Create(integrationId, integrationDtos);
            return Created(string.Empty, integrationId);
        }
    }
}
