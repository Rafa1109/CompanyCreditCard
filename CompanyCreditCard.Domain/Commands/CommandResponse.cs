using MediatR;
using System;

namespace CompanyCreditCard.Domain.Commands
{
    public abstract class Message : INotification
    {
        public string MessageType { get; protected set; }
        public long AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
