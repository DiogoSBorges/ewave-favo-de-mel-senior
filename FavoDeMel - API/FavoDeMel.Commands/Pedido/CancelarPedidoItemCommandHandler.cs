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
    public class CancelarPedidoItemCommandHandler : ICommandHandler<CancelarPedidoItemCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public CancelarPedidoItemCommandHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task HandleAsync(CancelarPedidoItemCommand command)
        {
            var pedido = await _pedidoRepository.GetByAsync(command.Id);
            if (pedido.IsNull()) throw new PedidoNaoEncontradoException();

            var item = pedido.Itens.SingleOrDefault(x => x.Id == command.PedidoItemId);
            if (item.IsNull()) throw new PedidoItemNaoEncontradoException();

            if (item.Producao.IsNotNull())
            {
                if (item.SituacaoId != (int)EPedidoItemSituacao.AgardandoProducao) throw new PedidoItemSituacaoInvalidaAoCancelarException();
            }
            else
            {
                if (item.SituacaoId != (int)EPedidoItemSituacao.Finalizado) throw new PedidoItemSituacaoInvalidaAoCancelarException();
            }                     

            item.SituacaoId = (int)EPedidoItemSituacao.Cancelado;

            var possuiItensNaoCancelados = pedido.Itens.Any(x => x.SituacaoId != (int)EPedidoItemSituacao.Cancelado);

            if (!possuiItensNaoCancelados)
            {
                pedido.SituacaoId = (int)EPedidoSituacao.Cancelado;
            }
            else
            {
                var possuiApenasItensNaoEntregues = pedido.Itens.Any(x => x.SituacaoId != (int)EPedidoItemSituacao.Cancelado && x.SituacaoId != (int)EPedidoItemSituacao.Entregue);
                if (!possuiApenasItensNaoEntregues)
                {
                    pedido.SituacaoId = (int)EPedidoSituacao.Entregue;
                }
            }
        }
    }
}
