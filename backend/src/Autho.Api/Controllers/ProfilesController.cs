using Autho.Api.Filters;
using Autho.Application.Contracts;
using Autho.Application.Queries.Interfaces;
using Autho.Application.Queries.Parameters;
using Autho.Application.Services.Interfaces;
using Autho.Core.Enums;
using Autho.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Autho.Api.Controllers
{
    public class ProfilesController : BaseController
    {
        private readonly IProfileAppService _profileAppService;
        private readonly IProfileAppQuery _profileAppQuery;

        public ProfilesController(INotificationHandler<DomainNotification> notifications,
                                  IProfileAppService profileAppService,
                                  IProfileAppQuery profileAppQuery) : base(notifications)
        {
            _profileAppService = profileAppService;
            _profileAppQuery = profileAppQuery;
        }

        [HttpGet, Route("api/profiles"), AuthorizationRequirement(Permission.ProfileView)]
        public IActionResult Get([FromQuery] ProfileParameters parameters)
        {
            return Ok(_profileAppQuery.GetPaged(parameters));
        }

        [HttpPost, Route("api/profiles"), AuthorizationRequirement(Permission.ProfileInsert)]
        public async Task<IActionResult> Post([FromBody] ProfileCreationDto creationDto)
        {
            await _profileAppService.Add(creationDto);

            return CustomResponse("api/profiles");
        }

        [HttpPut, Route("api/profiles/{id}"), AuthorizationRequirement(Permission.ProfileUpdate)]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] ProfileCreationDto creationDto)
        {
            await _profileAppService.Update(id, creationDto);

            return CustomResponse("api/profiles", id);
        }

        [HttpDelete, Route("api/profiles/{id}"), AuthorizationRequirement(Permission.ProfileDelete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _profileAppService.Remove(id);

            return CustomResponse("api/profiles", id);
        }
    }
}
