using Autho.Api.Scope.Responses;
using Autho.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autho.Api.Controllers
{
    [ApiController]
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        protected DomainNotificationHandler _notifications =>
            (DomainNotificationHandler)HttpContext.RequestServices.GetRequiredService<INotificationHandler<DomainNotification>>();

        protected IActionResult CustomResponse(string instance)
        {
            if (_notifications.HasNotifications())
            {
                var response = new Response(instance);

                _notifications.GetNotifications().ForEach(notification =>
                {
                    response.Errors.Add(new ResponseError(notification.Type, notification.Error, notification.Detail));
                });

                return BadRequest(response);
            }

            return NoContent();
        }

        protected IActionResult CustomResponse(string instance, Guid id)
        {
            return CustomResponse(string.Format("{0}/{1}", instance, id));
        }

        protected IActionResult ServiceUnavailable(object value)
        {
            return StatusCode(StatusCodes.Status503ServiceUnavailable, value);
        }
    }
}
