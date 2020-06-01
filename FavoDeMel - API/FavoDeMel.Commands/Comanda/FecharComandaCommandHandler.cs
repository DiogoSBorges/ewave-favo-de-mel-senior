using FavoDeMel.Domain.Commands;
using FavoDeMel.Domain.Enums;
using FavoDeMel.Domain.Exceptions;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infrastructure.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FavoDeMel.Commands.Comanda
{
    public class FecharComandaCommandHandler : ICommandHandler<FecharComandaCommand>
    {

        private readonly IComandaRepository _comandaRepository;

        private readonly IPedidoRepository _pedidoRepository;

        public FecharComandaCommandHandler(IComandaRepository comandaRepository,
            IPedidoRepository pedidoRepository)
        {
            _comandaRepository = comandaRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task HandleAsync(FecharComandaCommand command)
        {
            var comanda = await _comandaRepository.GetByAsync(command.Id);
            if (comanda.IsNull()) throw new ComandaNaoEncontradaException();

            if (comanda.SituacaoId != (int)EComandaSituacao.Aberta) throw new ComandaSituacaoInvalicaAoFecharException();

            var movimento = comanda.Movimentos.SingleOrDefault(x => x.DataAbertura.IsNotNull() && x.DataFechamento.IsNull());
            if (movimento.IsNull()) throw new ComandaMovimentoAbertoNaoEncontradoException();

            var pedidos = await _pedidoRepository.ObterPedidosPorAsync(movimento.Id);

            var possuiPedidoNaoEntregues = pedidos.Any(x => x.SituacaoId != (int)EPedidoSituacao.Entregue && x.SituacaoId != (int)EPedidoSituacao.Cancelado);
            if (possuiPedidoNaoEntregues) throw new ComandaPossuiPedidosNaoEntreguesException();


            comanda.SituacaoId = (int)EComandaSituacao.Fechada;
            movimento.DataFechamento = DateTime.Now;

            await _comandaRepository.UpdateAsync(comanda);
        }
    }
}
