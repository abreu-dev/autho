using Autho.Application.Services.Interfaces;
using Autho.Domain.Core.Validations;
using Autho.Domain.Core.Validations.Interfaces;
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

        /// <summary>
        /// Obtain the actual state of the application
        /// </summary>
        /// <response code="204">If the server and database are running</response>
        /// <response code="503">If the database is unavailable</response>
        [HttpGet]
        [Route("api/health")]
        [ProducesResponseType(204)]
        [ProducesResponseType(503, Type = typeof(ICollection<IResultError>))]
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

            return NoContent();
        }
    }
}
