using FavoDeMel.Commands.Pedido;
using FavoDeMel.Domain.Dto;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FavoDeMel.Tests.commands.pedido
{
    public class CriarPedidoCommandTests
    {
        private readonly int _comandaId = 1;
        private readonly string _observacao = "observacao";
        private readonly List<PedidoItemDto> _pedidos = new List<PedidoItemDto> { new PedidoItemDto { ProdutoId = 1 } };

        [Fact]
        public void Quando_criar_comanda_com_comandaId_invalido()
        {
            var act = new Action(() => new CriarPedidoCommand(default(int), _observacao, _pedidos));
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("comandaId");
        }

        [Fact]
        public void Quando_criar_comanda_com_pedidos_vazios()
        {
            var act = new Action(() => new CriarPedidoCommand(_comandaId, _observacao, null));
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("itens");
        }
    }
}
