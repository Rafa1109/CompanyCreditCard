using CompanyCreditCard.Domain.Core.Commands;
using CompanyCreditCard.Domain.Interfaces;
using CompanyCreditCard.Infra.Data.Context;

namespace CompanyCreditCard.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyCreditCardContext _context;

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
