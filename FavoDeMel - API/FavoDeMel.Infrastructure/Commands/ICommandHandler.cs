using System.Threading.Tasks;

namespace FavoDeMel.Domain.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
