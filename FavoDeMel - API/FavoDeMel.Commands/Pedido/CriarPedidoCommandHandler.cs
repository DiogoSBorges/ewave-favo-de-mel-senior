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
    public class CriarPedidoCommandHandler : ICommandHandler<CriarPedidoCommand>
    {
        private readonly IComandaRepository _comandaRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public CriarPedidoCommandHandler(
            IComandaRepository comandaRepository,
            IPedidoRepository pedidoRepository,
            IProdutoRepository produtoRepository)
        {
            _comandaRepository = comandaRepository;
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task HandleAsync(CriarPedidoCommand command)
        {
            var comanda = await _comandaRepository.GetByAsync(command.ComandaId);
            if (comanda.IsNull()) throw new ComandaNaoEncontradaException();

            if (comanda.SituacaoId != (int)EComandaSituacao.Aberta) throw new ComandaMovimentoAbertoNaoEncontradoException();

            var comandaMovimento = comanda.Movimentos.SingleOrDefault(x => x.DataAbertura.IsNotNull() && x.DataFechamento.IsNull());
            if (comandaMovimento.IsNull()) throw new ArgumentNullException();

            var itensPedido = new List<PedidoItem>();

            foreach (var item in command.Itens)
            {

                var produto = await _produtoRepository.GetByAsync(item.ProdutoId);
                if (produto.IsNull()) throw new ProdutoNaoEncontradoException();

                var itemPedido = new PedidoItem
                {
                    ProdutoId = item.ProdutoId,
                    Observacao = item.Observacao
                };

                if (produto.TempoPreparo.HasValue)
                {
                    itemPedido.Producao = new PedidoItemProducao
                    {
                        PrioridadeId = (int)EPedidoItemProducaoPrioridade.Normal
                    };

                    itemPedido.SituacaoId = (int)EPedidoItemSituacao.AgardandoProducao;
                }
                else
                {
                    itemPedido.SituacaoId = (int)EPedidoItemSituacao.Finalizado;
                }

                itensPedido.Add(itemPedido);
            }

            var pedido = new Domain.Models.Pedido
            {
                SituacaoId = (int)EPedidoSituacao.Criado,
                Observacao = command.Observacao,
                Data = DateTime.Now,
                ComandaMovimentoId = comandaMovimento.Id,
                Itens = itensPedido
            };

            await _pedidoRepository.AddAsync(pedido);

        }
    }
}
