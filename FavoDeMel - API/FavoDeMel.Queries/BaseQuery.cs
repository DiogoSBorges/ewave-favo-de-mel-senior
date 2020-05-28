using FavoDeMel.Domain.Queries;
using FavoDeMel.Infrastructure.Extensions;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FavoDeMel.Queries
{
    public abstract class BaseQuery
    {
       protected readonly string ConnectionString;

        public BaseQuery(string connectionString)
        {
            if(connectionString.IsNull()) throw new ArgumentNullException(nameof(connectionString));

            ConnectionString = connectionString;
        }

        protected virtual IDbConnection CreateConnection() => new SqlConnection(ConnectionString);
    }
}
