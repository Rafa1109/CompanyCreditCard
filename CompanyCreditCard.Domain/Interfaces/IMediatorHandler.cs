using CompanyCreditCard.Domain.Commands;
using CompanyCreditCard.Domain.Core.Events;
using System.Threading.Tasks;

namespace CompanyCreditCard.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task EnviarComando<T>(T comando) where T : Command;
    }
}
