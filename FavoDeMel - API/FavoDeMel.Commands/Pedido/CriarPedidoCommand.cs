using FavoDeMel.Domain.Commands;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Infrastructure.Extensions;
using System;
using System.Collections.Generic;

namespace FavoDeMel.Commands.Pedido
{
    public class CriarPedidoCommand : ICommand
    {
        public int ComandaId { get; set; }

        public string Observacao { get; set; }
        public List<PedidoItemDto> Itens { get; set; }

        public CriarPedidoCommand(int comandaId, string observacao, List<PedidoItemDto> itens)
        {
            if (comandaId.IsLessThanZero()) throw new ArgumentNullException(nameof(comandaId));
            if (itens.IsNull() || itens.Count == 0) throw new ArgumentNullException(nameof(itens));

            ComandaId = comandaId;
            Observacao = observacao;
            Itens = itens;
        }
    }
}
