using FavoDeMel.Domain.Commands;
using System;
using System.Threading.Tasks;

namespace FavoDeMel.Application.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public async Task HandleAsync<T>(T command) where T : ICommand
        {
            var service = this._serviceProvider.GetService(typeof(ICommandHandler<T>)) as ICommandHandler<T>;
            await service.HandleAsync(command);
        }
    }
}