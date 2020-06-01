using FavoDeMel.Domain.Commands;
using FavoDeMel.Infrastructure.Extensions;
using System;

namespace FavoDeMel.Commands.Comanda
{
    public class FecharComandaCommand : ICommand
    {
        public int Id { get; }

        public FecharComandaCommand(int id)
        {
            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));

            Id = id;
        }

    }
}
