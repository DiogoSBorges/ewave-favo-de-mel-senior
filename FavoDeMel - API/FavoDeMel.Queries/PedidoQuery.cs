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
														[PIP].[Id] AS [ProducaoId],	
														[PIP].[DataInicio] AS [ProducaoDataInicio],
														[PIP].[PrioridadeId] AS [ProducaoPrioridadeId],
														[PIPP].[Nome] AS [ProducaoPrioridade]	
													FROM [dbo].[PedidoItem] AS [PI]
													INNER JOIN [dbo].[PedidoItemSituacao] AS [PIS] ON [PIS].[Id] = [PI].[SituacaoId]
													INNER JOIN [dbo].[Produto] AS [P] ON [P].[Id] = [PI].[ProdutoId]
													LEFT JOIN [dbo].[PedidoItemProducao]  AS [PIP] ON [PIP].[PedidoItemId] = [PI].[Id]
													LEFT JOIN [dbo].[PedidoItemProducaoPrioridade] AS [PIPP] ON [PIPP].[Id] = [PIP].[PrioridadeId]
													WHERE [PI].[PedidoId] = @PedidoId";




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
    }
}
