using FavoDeMel.Domain.Commands;
using FavoDeMel.Infrastructure.Extensions;
using System;

namespace FavoDeMel.Commands.Pedido
{
    public class EntregarPedidoItemCommand : ICommand
    {
        public int Id { get; set; }

        public int PedidoItemId { get; set; }

        public EntregarPedidoItemCommand(int id, int pedidoItemId)
        {
            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));
            if (pedidoItemId.IsLessThanZero()) throw new ArgumentNullException(nameof(pedidoItemId));

            Id = id;
            PedidoItemId = pedidoItemId;
        }
    }
}
