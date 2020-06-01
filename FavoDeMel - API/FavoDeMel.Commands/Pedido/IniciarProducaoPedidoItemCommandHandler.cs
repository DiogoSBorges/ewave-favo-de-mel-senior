using FavoDeMel.Domain.Commands;
using FavoDeMel.Domain.Enums;
using FavoDeMel.Domain.Exceptions;
using FavoDeMel.Domain.Models;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoDeMel.Commands.Pedido
{
    public class IniciarProducaoPedidoItemCommandHandler : ICommandHandler<IniciarProducaoPedidoItemCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public IniciarProducaoPedidoItemCommandHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task HandleAsync(IniciarProducaoPedidoItemCommand command)
        {
            var pedido = await _pedidoRepository.GetByAsync(command.Id);
            if (pedido.IsNull()) throw new PedidoNaoEncontradoException();

            var item = pedido.Itens.SingleOrDefault(x => x.Id == command.PedidoItemId);
            if (item.IsNull()) throw new PedidoItemNaoEncontradoException(); 

            if(item.SituacaoId != (int)EPedidoItemSituacao.AgardandoProducao) throw new PedidoItemSituacaoInvalidaAoIniciarProducaoException();

            item.SituacaoId = (int)EPedidoItemSituacao.EmProducao;
            item.Producao.DataInicio = DateTime.Now;

            await _pedidoRepository.UpdateAsync(pedido);
        }
    }
}
