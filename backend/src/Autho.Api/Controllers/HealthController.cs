using Autho.Application.Services.Interfaces;
using Autho.Domain.Core.Notifications;
using Autho.Domain.Core.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Autho.Api.Controllers
{
    public class HealthController : BaseController
    {
        private readonly IHealthAppService _healthAppService;

        public HealthController(INotificationHandler<DomainNotification> notifications,
                                IHealthAppService healthAppService) : base(notifications)
        {
            _healthAppService = healthAppService;
        }

        [HttpGet, Route("api/health")]
        public IActionResult Get()
        {
            var result = _healthAppService.CheckHealthy();

            if (result.Type == ResultType.Failure)
            {
                return ServiceUnavailable(new
                {
                    result.Errors
                });
            }

            return Ok();
        }
    }
}
