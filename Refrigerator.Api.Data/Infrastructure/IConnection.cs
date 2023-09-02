using System.Data;

namespace Refrigerator.Api.Data.Infrastructure
{
    public interface IConnection
    {
        /// <summary>
        /// Get Sql Connection based on connection string.
        /// </summary>
        /// <param name="connectionString">The connectionString.</param>
        /// <param name="open">whether to open the connection</param>
        /// <returns></returns>
        IDbConnection GetSqlConnection(string connectionString, bool open = true);
    }
}