using FavoDeMel.Domain.Commands;
using FavoDeMel.Domain.Enums;
using FavoDeMel.Domain.Exceptions;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infrastructure.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace FavoDeMel.Commands.Pedido
{
    public class EntregarPedidoItemCommandHandler : ICommandHandler<EntregarPedidoItemCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public EntregarPedidoItemCommandHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task HandleAsync(EntregarPedidoItemCommand command)
        {
            var pedido = await _pedidoRepository.GetByAsync(command.Id);
            if (pedido.IsNull()) throw new PedidoNaoEncontradoException();

            var item = pedido.Itens.SingleOrDefault(x => x.Id == command.PedidoItemId);
            if (item.IsNull()) throw new PedidoItemNaoEncontradoException();

            if (item.SituacaoId != (int)EPedidoItemSituacao.Finalizado) throw new PedidoItemSituacaoInvalidaAoEntregarException();

            item.SituacaoId = (int)EPedidoItemSituacao.Entregue;

            var possuiItensNaoEntregues = pedido.Itens.Any(x => x.SituacaoId != (int)EPedidoItemSituacao.Entregue && x.SituacaoId != (int)EPedidoItemSituacao.Cancelado);

            if (!possuiItensNaoEntregues)
            {
                pedido.SituacaoId = (int)EPedidoSituacao.Entregue;
            }

            await _pedidoRepository.UpdateAsync(pedido);
        }
    }
}
