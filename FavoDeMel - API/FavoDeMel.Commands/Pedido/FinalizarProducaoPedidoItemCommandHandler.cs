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
    public class FinalizarProducaoPedidoItemCommandHandler : ICommandHandler<FinalizarProducaoPedidoItemCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public FinalizarProducaoPedidoItemCommandHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task HandleAsync(FinalizarProducaoPedidoItemCommand command)
        {
            var pedido = await _pedidoRepository.GetByAsync(command.Id);
            if (pedido.IsNull()) throw new PedidoNaoEncontradoException();

            var item = pedido.Items.SingleOrDefault(x => x.Id == command.PedidoItemId);
            if (item.IsNull()) throw new PedidoItemNaoEncontradoException(); 

            if(item.SituacaoId != (int)EPedidoItemSituacao.EmProducao) throw new PedidoItemSituacaoInvalidaAoFinalizarProducaoException();

            item.SituacaoId = (int)EPedidoItemSituacao.Finalizado;
            item.Producao.DataFim = DateTime.Now;
        }
    }
}
