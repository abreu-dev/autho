using Autho.Api.Scope.Responses;
using Autho.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Autho.Api.Scope.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly DomainNotificationHandler _notificationHandler;

        public NotificationFilter(INotificationHandler<DomainNotification> notificationHandler)
        {
            _notificationHandler = (DomainNotificationHandler)notificationHandler;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationHandler.HasNotifications())
            {
                context.Result = GetBadRequestObjectResult(_notificationHandler.GetNotifications(), context.HttpContext.Request.Path.Value);
            }

            await next();
        }

        public BadRequestObjectResult GetBadRequestObjectResult(List<DomainNotification> notifications, string? instance)
        {
            var response = new BadRequestResponse(instance);

            notifications.ForEach(notification =>
            {
                response.Errors.Add(new BadRequestResponseError(notification.Type, notification.Error, notification.Detail));
            });

            return new BadRequestObjectResult(response);
        }
    }
}
