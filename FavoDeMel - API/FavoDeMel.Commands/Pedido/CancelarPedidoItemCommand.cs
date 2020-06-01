using FavoDeMel.Domain.Commands;
using FavoDeMel.Infrastructure.Extensions;
using System;

namespace FavoDeMel.Commands.Pedido
{
    public class CancelarPedidoItemCommand : ICommand
    {
        public int Id { get; set; }

        public int PedidoItemId { get; set; }

        public CancelarPedidoItemCommand(int id, int pedidoItemId)
        {
            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));
            if (pedidoItemId.IsLessThanZero()) throw new ArgumentNullException(nameof(pedidoItemId));

            Id = id;
            PedidoItemId = pedidoItemId;
        }
    }
}
