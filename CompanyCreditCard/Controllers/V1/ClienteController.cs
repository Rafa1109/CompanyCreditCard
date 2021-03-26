using CompanyCreditCard.Controllers.Commons;
using CompanyCreditCard.Domain.Core.Notifications;
using CompanyCreditCard.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompanyCreditCard.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/cliente")]
    public class ClienteController : BaseController
    {
        private readonly IMediatorHandler _mediator;
        public ClienteController(
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Response();
        }

        [AllowAnonymous]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarCliente()
        {
            return Response();
        }
    }
}
