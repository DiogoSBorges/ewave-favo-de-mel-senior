using Dapper;
using FavoDeMel.Domain.Queries;
using FavoDeMel.Domain.Queries.Views;
using FavoDeMel.Infrastructure.Data;
using FavoDeMel.Infrastructure.Extensions;
using FavoDeMel.Infrastructure.Providers;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FavoDeMel.Queries
{
    public class ComandaQuery : BaseQuery, IComandaQuery
    {
		private readonly IPedidoQuery _pedidoQuery;

		private const string ConsultaSimples = @"SELECT 
												[C].[Id], 
												[C].[Numero],
												[C].[SituacaoId],
												[CS].[Nome] AS [Situacao],
												ROW_NUMBER() OVER(ORDER BY [C].[Numero]) AS [RowNum]										      
											  FROM [dbo].[Comanda] AS [C]
											  INNER JOIN [dbo].[ComandaSituacao] AS [CS] ON [CS].[Id] = [C].[SituacaoId]";

		private string ConsultaComPaginacao = $@";WITH [T] AS 
													({ConsultaSimples}) 
												SELECT 	
													[T].[Id], 
													[T].[Numero],
													[T].[SituacaoId],
													[T].[Situacao]
												FROM [T]
												WHERE [T].[RowNum] > (@PageSize * (@PageNumber - 1))
												AND [T].[RowNum] <= (@PageSize * @PageNumber)
												ORDER BY [T].[RowNum]";

		private string ObterComandaDetalhada = @"SELECT 
												 [C].[Id],
												 [C].[Numero],
												 [C].[SituacaoId],
												 [CS].[Nome] AS [Situacao]
												FROM [dbo].[Comanda] AS [C]
												INNER JOIN [dbo].[ComandaSituacao] AS [CS] ON [CS].[Id] = [C].[SituacaoId]
												WHERE [C].[Id] = @ComandaId;


												SELECT 
													[P].[Id],
													[p].[Data],
													[P].[Observacao],
													[P].[SituacaoId],
													[PS].[Nome] AS [Situacao]
												FROM [dbo].[Pedido] AS [P]
												INNER JOIN [dbo].[PedidoSituacao] AS [PS] ON [PS].[Id] = [P].[SituacaoId] 
												INNER JOIN [dbo].[ComandaMovimento] AS [CM] ON [CM].[Id] = [P].[ComandaMovimentoId]
												WHERE [CM].[ComandaId] = @ComandaId AND CM.[DataAbertura] IS NOT NULL AND CM.[DataFechamento] IS NULL
												ORDER BY [P].[Data];";


		public ComandaQuery(IOptions<DBProvider> provider, IPedidoQuery pedidoQuery) : base(provider)
        {
			_pedidoQuery = pedidoQuery;
        }        

        public async Task<IEnumerable<ComandaView>> ObterTodasAsync(PaginacaoInfo paginacao)
        {
			var parameters = new DynamicParameters();
			parameters.Add("@PageNumber", paginacao.Pagina, DbType.Int32);
			parameters.Add("@PageSize", paginacao.Linhas, DbType.Int32);

            using (var conn = CreateConnection())
            {
                return await conn.QueryAsync<ComandaView>(ConsultaComPaginacao, parameters);
            }
        }

		public async Task<ComandaDetalhadaView> ObterComandaDetalhadaPorAsync(int id)
		{
			using (var conn = CreateConnection())
			{
				using (var multi = await conn.QueryMultipleAsync(ObterComandaDetalhada, new { ComandaId = id }))
				{
					var comanda = await multi.ReadSingleOrDefaultAsync<ComandaDetalhadaView>();
                    if (comanda.IsNotNull())
                    {
						comanda.Pedidos = await multi.ReadAsync<PedidoView>();

						foreach(var pedido in comanda.Pedidos)
                        {
							pedido.Itens = await _pedidoQuery.ObterPedidoItensPorAsync(pedido.Id);
                        }
					}					

					return comanda;
				}
			}
		}
	}
}
