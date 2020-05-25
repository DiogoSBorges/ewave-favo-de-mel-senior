using FavoDeMel.Domain.Commands;
using FavoDeMel.Domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace FavoDeMel.Application.Commands
{
    public class AdicionarTesteCommandHandler : ICommandHandler<AdicionarTesteCommand>
    {
        public Task HandleAsync(AdicionarTesteCommand command)
        {

            var a = command.Valor;
            return Task.CompletedTask;

            //throw new TesteException();
        }
    }
}
