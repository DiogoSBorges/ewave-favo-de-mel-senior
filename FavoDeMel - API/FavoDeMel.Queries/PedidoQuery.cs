using Dapper;
using FavoDeMel.Domain.Queries;
using FavoDeMel.Domain.Queries.Views;
using FavoDeMel.Infrastructure.Providers;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Queries
{
    public class PedidoQuery : BaseQuery, IPedidoQuery
    {
        private readonly IProdutoQuery _produtoQuery;

        private const string ObterItensPorPedidoId = @"SELECT 
														[PI].[Id],
														[PI].[Observacao],
														[PI].[SituacaoId],
														[PIS].[Nome] AS [Situacao],
														[PI].[ProdutoId],	
														[p].[Nome] AS [Produto],
														[p].[Valor],
														[PIP].[DataInicio] AS [ProducaoDataInicio],
														[PIP].[PrioridadeId] AS [ProducaoPrioridadeId],
														[PIPP].[Nome] AS [ProducaoPrioridade]	
													FROM [dbo].[PedidoItem] AS [PI]
													INNER JOIN [dbo].[PedidoItemSituacao] AS [PIS] ON [PIS].[Id] = [PI].[SituacaoId]
													INNER JOIN [dbo].[Produto] AS [P] ON [P].[Id] = [PI].[ProdutoId]
													LEFT JOIN [dbo].[PedidoItemProducao]  AS [PIP] ON [PIP].[PedidoItemId] = [PI].[Id]
													LEFT JOIN [dbo].[PedidoItemProducaoPrioridade] AS [PIPP] ON [PIPP].[Id] = [PIP].[PrioridadeId]
													WHERE [PI].[PedidoId] = @PedidoId";

        private const string ObterPedidoItensAguardandoProducaoEEmProducao = @"SELECT
																				[PI].[Id] AS [PedidoItemId],
																				[PI].[Observacao],
																				[PI].[SituacaoId],
																				[PIS].[Nome] AS [Situacao],
																				[PI].[ProdutoId],	
																				[PROD].[Nome] AS [Produto],
																				[PROD].[Valor],	
																				[PIP].[DataInicio] AS [ProducaoDataInicio],
																				[PIP].[PrioridadeId] AS [ProducaoPrioridadeId],
																				[PIPP].[Nome] AS [ProducaoPrioridade],
																				[C].[Id] AS [ComandaId],
																				[C].[Numero] AS [ComandaNumero]	,
																				[P].[Id] AS [PedidoId]
																			FROM [dbo].[PedidoItemProducao] AS [PIP]
																			INNER JOIN [dbo].[PedidoItemProducaoPrioridade] AS [PIPP] ON [PIPP].[Id] = [PIP].[PrioridadeId]
																			INNER JOIN [dbo].[PedidoItem] AS [PI] ON [PI].[Id] = [PIP].[PedidoItemId]
																			INNER JOIN [dbo].[Produto] AS [PROD] ON [PROD].[Id] = [PI].[ProdutoId]
																			INNER JOIN [dbo].[PedidoItemSituacao] AS [PIS] ON [PIS].[Id] = [PI].[SituacaoId]
																			INNER JOIN [dbo].[Pedido] AS [P] ON [P].[Id] = [PI].[PedidoId]
																			INNER JOIN [dbo].[ComandaMovimento] AS [CM] ON [CM].[Id] = [P].[ComandaMovimentoId]
																			INNER JOIN [dbo].[Comanda] AS [C] ON [C].[Id] = [CM].[ComandaId]
																			WHERE [PI].[SituacaoId] = 1
																			ORDER BY [PIP].[PrioridadeId] DESC, p.[Data];


																			SELECT
																				[PI].[Id] AS [PedidoItemId],
																				[PI].[Observacao],
																				[PI].[SituacaoId],
																				[PIS].[Nome] AS [Situacao],
																				[PI].[ProdutoId],	
																				[PROD].[Nome] AS [Produto],
																				[PROD].[Valor],
																				[PIP].[DataInicio] AS [ProducaoDataInicio],
																				[PIP].[PrioridadeId] AS [ProducaoPrioridadeId],
																				[PIPP].[Nome] AS [ProducaoPrioridade],
																				[C].[Id] AS [ComandaId],
																				[C].[Numero] AS [ComandaNumero]	,
																				[P].[Id] AS [PedidoId]
																			FROM [dbo].[PedidoItemProducao] AS [PIP]
																			INNER JOIN [dbo].[PedidoItemProducaoPrioridade] AS [PIPP] ON [PIPP].[Id] = [PIP].[PrioridadeId]
																			INNER JOIN [dbo].[PedidoItem] AS [PI] ON [PI].[Id] = [PIP].[PedidoItemId]
																			INNER JOIN [dbo].[Produto] AS [PROD] ON [PROD].[Id] = [PI].[ProdutoId]
																			INNER JOIN [dbo].[PedidoItemSituacao] AS [PIS] ON [PIS].[Id] = [PI].[SituacaoId]
																			INNER JOIN [dbo].[Pedido] AS [P] ON [P].[Id] = [PI].[PedidoId]
																			INNER JOIN [dbo].[ComandaMovimento] AS [CM] ON [CM].[Id] = [P].[ComandaMovimentoId]
																			INNER JOIN [dbo].[Comanda] AS [C] ON [C].[Id] = [CM].[ComandaId]
																			WHERE [PI].[SituacaoId] = 2
																			ORDER BY [PIP].[DataInicio]";




        public PedidoQuery(IOptions<DBProvider> provider, IProdutoQuery produtoQuery) : base(provider)
        {
            _produtoQuery = produtoQuery;
        }


        public async Task<IEnumerable<PedidoItemDetalhadoView>> ObterPedidoItensPorAsync(int pedidoId)
        {
            using (var conn = CreateConnection())
            {
                return await conn.QueryAsync<PedidoItemDetalhadoView>(ObterItensPorPedidoId, new { PedidoId = pedidoId });
            }
        }

        public async Task<PedidoItemProducaoView> ObterPedidoItenProducaoAsync()
        {
            using (var conn = CreateConnection())
            {
                using (var multi = await conn.QueryMultipleAsync(ObterPedidoItensAguardandoProducaoEEmProducao))
                {
					var pedidoProducao = new PedidoItemProducaoView
					{
						ItensAguardandoProducao = await multi.ReadAsync<PedidoItemProducaoDetalhadoView>(),
						ItensEmProducao = await multi.ReadAsync<PedidoItemProducaoDetalhadoView>()
					};

					return pedidoProducao;
                }
            }
        }
    }
}

