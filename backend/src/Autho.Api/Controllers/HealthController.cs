using Autho.Application.Services.Interfaces;
using Autho.Domain.Core.Validations;
using Microsoft.AspNetCore.Mvc;

namespace Autho.Api.Controllers
{
    public class HealthController : BaseController
    {
        private readonly IHealthAppService _healthAppService;

        public HealthController(IHealthAppService healthAppService)
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
