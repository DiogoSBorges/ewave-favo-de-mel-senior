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
    public class ProdutQuery : BaseQuery, IProdutoQuery
    {

		private const string ConsultaSimples = @"SELECT 
												[P].[Id], 
												[P].[Nome],
                                                [P].[Valor],
												[P].[TipoId],
												[PT].[Nome] AS [Tipo],
												ROW_NUMBER() OVER(ORDER BY [P].[Nome]) AS [RowNum]										      
											  FROM [dbo].[Produto] AS [P]
											  INNER JOIN [dbo].[ProdutoTipo] AS [PT] ON [PT].[Id] = [P].[TipoId]";		


		public ProdutQuery(IOptions<DBProvider> provider) : base(provider)
        {
        }

        public async Task<IEnumerable<ProdutoView>> ObterTodosAsync()
        {			

            using (var conn = CreateConnection())
            {
                return await conn.QueryAsync<ProdutoView>(ConsultaSimples);
            }
        }
    }
}
