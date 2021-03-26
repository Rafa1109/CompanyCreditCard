using MediatR;
using System;

namespace CompanyCreditCard.Domain.Commands
{
    public abstract class Command : Message/*, IRequest<ValidationResult>*/, IBaseRequest
    {
        public DateTime Timestamp { get; private set; }
        // public long Id { get; protected set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }

        /*public void SetId(long id)
        {
            Id = id;
        }*/

        // public ValidationResult ValidationResult { get; set; }
        // public abstract bool IsValid();
    }
}
