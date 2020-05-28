using FavoDeMel.Domain.Queries;
using FavoDeMel.Infrastructure.Extensions;
using FavoDeMel.Infrastructure.Providers;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FavoDeMel.Queries
{
    public abstract class BaseQuery
    {
       protected readonly string ConnectionString;

        public BaseQuery(IOptions<DBProvider> provider)
        {
            if (provider.Value.FavoDeMel.IsNull()) throw new ArgumentNullException(nameof(provider.Value.FavoDeMel));

            ConnectionString = provider.Value.FavoDeMel;
        }

        protected virtual IDbConnection CreateConnection() => new SqlConnection(ConnectionString);
    }
}
