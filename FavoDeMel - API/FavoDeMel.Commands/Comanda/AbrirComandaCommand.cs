using FavoDeMel.Domain.Commands;

namespace FavoDeMel.Commands.Comanda
{
    public class AbrirComandaCommand : ICommand
    {
        public int Id { get; }

        public AbrirComandaCommand(int id)
        {
            Id = id;
        }

    }
}
