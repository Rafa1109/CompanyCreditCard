using CompanyCreditCard.Domain.Commands.Cliente;
using CompanyCreditCard.Domain.Core.Notifications;
using CompanyCreditCard.Domain.Handlers;
using CompanyCreditCard.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyCreditCard.Domain.CommandHandlers.Cliente
{
    public class ClienteCommandHandler : CommandHandler,
        INotificationHandler<RegistrarClienteCommand>,
        INotificationHandler<AtualizarClienteCommand>
    {
        public ClienteCommandHandler(IUnitOfWork uow, IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications) : base(uow, mediator, notifications)
        {
        }

        public Task Handle(RegistrarClienteCommand notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public Task Handle(AtualizarClienteCommand notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
