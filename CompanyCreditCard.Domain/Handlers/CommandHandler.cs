using CompanyCreditCard.Domain.Core.Notifications;
using CompanyCreditCard.Domain.Interfaces;
using MediatR;
using System;

namespace CompanyCreditCard.Domain.Handlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly DomainNotificationHandler _notifications;

        protected readonly IMediatorHandler _mediator;

        protected CommandHandler(IUnitOfWork uow, IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
        }
        /*protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _mediator.PublicarEvento(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }*/
        protected bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            return CommitWithoutCheck();
        }

        protected bool CommitWithoutCheck()
        {
            try
            {
                _uow.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao salvar os dados no banco. {ex.Message}");
                _mediator.PublicarEvento(new DomainNotification("Commit",
                    $"Ocorreu um erro ao salvar os dados no banco. {ex.Message}"));
                return false;
            }
        }
    }
}
