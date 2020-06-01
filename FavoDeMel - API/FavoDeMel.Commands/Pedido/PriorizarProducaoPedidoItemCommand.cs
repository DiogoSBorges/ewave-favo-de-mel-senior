using FavoDeMel.Domain.Commands;
using FavoDeMel.Domain.Enums;
using FavoDeMel.Infrastructure.Extensions;
using System;

namespace FavoDeMel.Commands.Pedido
{
    public class PriorizarProducaoPedidoItemCommand : ICommand
    {
        public int Id { get; set; }

        public int PedidoItemId { get; set; }

        public int PrioridadeId { get; set; }

        public PriorizarProducaoPedidoItemCommand(int id, int pedidoItemId, int prioridadeId)
        {
            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));
            if (pedidoItemId.IsLessThanZero()) throw new ArgumentNullException(nameof(pedidoItemId));
            if (!Enum.IsDefined(typeof(EPedidoItemProducaoPrioridade), prioridadeId)) throw new ArgumentOutOfRangeException(nameof(prioridadeId));

            Id = id;
            PedidoItemId = pedidoItemId;
            PrioridadeId = prioridadeId;
        }
    }
}
