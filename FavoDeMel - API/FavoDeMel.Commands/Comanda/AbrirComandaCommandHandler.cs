using FavoDeMel.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FavoDeMel.Commands.Comanda
{
    public class AbrirComandaCommandHandler : ICommandHandler<AbrirComandaCommand>
    {
        public Task HandleAsync(AbrirComandaCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
