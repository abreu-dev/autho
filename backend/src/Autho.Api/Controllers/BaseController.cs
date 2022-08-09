using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autho.Api.Controllers
{
    [ApiController]
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ServiceUnavailable(object value)
        {
            return StatusCode(StatusCodes.Status503ServiceUnavailable, value);
        }
    }
}
