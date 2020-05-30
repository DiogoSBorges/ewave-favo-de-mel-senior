using Dapper;
using FavoDeMel.Domain.Queries;
using FavoDeMel.Domain.Queries.Views;
using FavoDeMel.Infrastructure.Data;
using FavoDeMel.Infrastructure.Providers;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FavoDeMel.Queries
{
    public class ComandaQuery : BaseQuery, IComandaQuery
    {

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


		public ComandaQuery(IOptions<DBProvider> provider) : base(provider)
        {
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
    }
}
