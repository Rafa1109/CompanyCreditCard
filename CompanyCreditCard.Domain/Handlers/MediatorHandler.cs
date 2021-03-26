using CompanyCreditCard.Domain.Commands;
using CompanyCreditCard.Domain.Core.Events;
using CompanyCreditCard.Domain.Interfaces;
using MediatR;
using System.Threading.Tasks;

namespace CompanyCreditCard.Domain.Handlers
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task EnviarComando<T>(T comando) where T : Command
        {
            await _mediator.Publish(comando);
        }
        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }
    }
}
