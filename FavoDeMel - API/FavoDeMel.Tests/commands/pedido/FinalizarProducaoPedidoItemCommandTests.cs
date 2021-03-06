﻿using FavoDeMel.Commands.Pedido;
using FluentAssertions;
using System;
using Xunit;

namespace FavoDeMel.Tests.commands.pedido
{
    public class FinalizarProducaoPedidoItemCommandTests
    {
        private readonly int _pedidoId = 1;
        private readonly int _itemDePedidoId = 2;

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Quando_finalizar_producao_de_item_com_Id_invalido(int pedidoId)
        {
            var act = new Action(() => new FinalizarProducaoPedidoItemCommand(pedidoId, _itemDePedidoId));
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("id");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Quando_finalizar_producao_de_item_com_pedidoItemId_invalido(int itemDePedidoId)
        {
            var act = new Action(() => new FinalizarProducaoPedidoItemCommand(_pedidoId, itemDePedidoId));
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("pedidoItemId");
        }
    }
}
