using Dapper;
using FavoDeMel.Domain.Queries;
using FavoDeMel.Domain.Queries.Views;
using FavoDeMel.Infrastructure.Providers;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Queries
{
    public class ComandaQuery : BaseQuery, IComandaQuery
    {

        public ComandaQuery(IOptions<DBProvider> provider) : base(provider.Value.FavoDeMel)
        {

        }

        public async Task<IEnumerable<ComandaView>> ObterTodasAsync()
        {
            var query = string.Format("SELECT C.Id, C.Numero FROM dbo.Comanda AS C");

            using (var conn = CreateConnection())
            {
                return await conn.QueryAsync<ComandaView>(query);
            }
        }
    }
}
