using FavoDeMel.Domain.Commands;
using FavoDeMel.Domain.Enums;
using FavoDeMel.Domain.Exceptions;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infrastructure.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FavoDeMel.Commands.Pedido
{
    public class PriorizarProducaoPedidoItemCommandHandler : ICommandHandler<PriorizarProducaoPedidoItemCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PriorizarProducaoPedidoItemCommandHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task HandleAsync(PriorizarProducaoPedidoItemCommand command)
        {
            var pedido = await _pedidoRepository.GetByAsync(command.Id);
            if (pedido.IsNull()) throw new PedidoNaoEncontradoException();

            var item = pedido.Itens.SingleOrDefault(x => x.Id == command.PedidoItemId);
            if (item.IsNull()) throw new PedidoItemNaoEncontradoException();

            if (item.SituacaoId != (int)EPedidoItemSituacao.AgardandoProducao) throw new PedidoItemSituacaoInvalidaAoPriorizarProducaoException();

            item.Producao.PrioridadeId = command.PrioridadeId;
        }
    }
}
