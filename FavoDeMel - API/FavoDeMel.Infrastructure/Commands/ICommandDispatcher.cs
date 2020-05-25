using FavoDeMel.Domain.Commands;
using System.Threading.Tasks;

public interface ICommandDispatcher
{
    Task HandleAsync<T>(T command) where T : ICommand;
}