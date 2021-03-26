using CompanyCreditCard.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CompanyCreditCard.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
    public interface ITransactionUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        void BeginTran();
        void Commit();
        void Rollback();
    }
}
