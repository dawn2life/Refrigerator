using Microsoft.Data.SqlClient;
using System.Data;

namespace Refrigerator.Api.Data.Infrastructure
{
    public class Connection : IConnection
    {
        /// <summary>
        /// Gets an open connection to the database specified by the connection string.
        /// </summary>
        /// <param name="connectionString">The connectionString.</param>
        /// <param name="open">Whether to return a open connection or not, by default the connection will be open</param>
        /// <returns>IDbConnection</returns>
        public IDbConnection GetSqlConnection(string connectionString, bool open = false)
        {
            var dbConnection = SqlClientFactory.Instance.CreateConnection();
            if (dbConnection == null)
                throw new DataException($"The sql provider cannot create a new connection");

            dbConnection.ConnectionString = connectionString;
            if (open) dbConnection.Open();
            return dbConnection;
        }
    }
}
