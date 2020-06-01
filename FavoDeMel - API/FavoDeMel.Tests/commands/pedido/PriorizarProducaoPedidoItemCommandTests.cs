using FavoDeMel.Commands.Pedido;
using FavoDeMel.Domain.Enums;
using FluentAssertions;
using System;
using Xunit;

namespace FavoDeMel.Tests.commands.pedido
{
    public class PriorizarProducaoPedidoItemCommandTests
    {
        private readonly int _pedidoId = 1;
        private readonly int _itemDePedidoId = 2;
        private readonly int _prioridadeId = (int) EPedidoItemProducaoPrioridade.Urgente;

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Quando_priorizar_producao_de_item_com_Id_invalido(int pedidoId)
        {
            var act = new Action(() => new PriorizarProducaoPedidoItemCommand(pedidoId, _itemDePedidoId,_prioridadeId));
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("id");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Quando_priorizar_producao_de_item_com_pedidoItemId_invalido(int itemDePedidoId)
        {
            var act = new Action(() => new PriorizarProducaoPedidoItemCommand(_pedidoId, itemDePedidoId, _prioridadeId));
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("pedidoItemId");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(4)]
        public void Quando_priorizar_producao_de_item_com_prioridadeId_invalido(int prioridadeId)
        {
            var act = new Action(() => new PriorizarProducaoPedidoItemCommand(_pedidoId, _itemDePedidoId, prioridadeId));
            act.Should().Throw<ArgumentOutOfRangeException>().And.ParamName.Should().Be("prioridadeId");
        }
    }
}
