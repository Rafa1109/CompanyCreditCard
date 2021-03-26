using CompanyCreditCard.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;

namespace CompanyCreditCard.Controllers.Commons
{
    [ApiController]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;


        protected BaseController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }
        protected new IActionResult Response(IEnumerable result,
            int page = 0, int size = 0, int max = 0, int totalItens = 0)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    currentPage = page,
                    maxPage = max,
                    itens = totalItens,
                    pageSize = size,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected bool OperacaoValida()
        {
            return !_notifications.HasNotifications();
        }
    }
}
