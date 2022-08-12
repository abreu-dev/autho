using Autho.Api.Scope.Filters;
using Autho.Application.Contracts.Integration;
using Autho.Application.Queries.Integrations.Interfaces;
using Autho.Application.Services.Integration.Interfaces;
using Autho.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Autho.Api.Controllers
{
    public class IntegrationController : BaseController
    {
        private readonly IIntegrationAppService _integrationAppService;
        private readonly IIntegrationAppQuery _integrationAppQuery;

        public IntegrationController(IIntegrationAppService integrationAppService,
                                     IIntegrationAppQuery integrationAppQuery)
        {
            _integrationAppService = integrationAppService;
            _integrationAppQuery = integrationAppQuery;
        }

        /// <summary>
        /// Add a list of users
        /// </summary>
        /// <response code="201">If request was successfully created</response>
        [HttpPost]
        [Route("api/integrations/users")]
        [AuthorizationRequirement(Permission.UserIntegrationInsert)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Post([FromBody] IEnumerable<IntegrationUserDto> integrationDtos)
        {
            var integrationId = Guid.NewGuid();
            await _integrationAppService.Create(integrationId, integrationDtos);
            return Created(string.Empty, integrationId);
        }

        /// <summary>
        /// Process the integration of users
        /// </summary>
        /// <response code="201">If request was successfully created</response>
        [HttpPost]
        [Route("api/integrations/users:process")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Process()
        {
            await _integrationAppService.ProcessUser();
            return Created(string.Empty, null);
        }

        /// <summary>
        /// Obtain a list of permissions
        /// </summary>
        [HttpGet]
        [Route("api/integrations/{id}")]
        [AuthorizationRequirement(Permission.PermissionView)]
        [ProducesResponseType(200, Type = typeof(IntegrationDto))]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_integrationAppQuery.Get(id));
        }
    }
}
