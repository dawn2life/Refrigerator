using Dapper;
using Microsoft.Extensions.Options;
using Refrigerator.Api.Data.Infrastructure;
using Refrigerator.Api.Data.SqlConstants;
using Refrigerator.Api.Domain.Configurations;
using Refrigerator.Api.Domain.Models;
using Refrigerator.Api.Domain.Repositories;

namespace Refrigerator.Api.Data.Repositories
{
    public class FridgeActivityLogRepository : IFridgeActivityLogRepository
    {
        private readonly IConnection _conn;
        private readonly ConnectionStrings _connStrings;

        public FridgeActivityLogRepository(IOptions<ConnectionStrings> connStrings,
                                           IConnection conn)
        {
            _conn = conn;
            _connStrings = connStrings.Value;
        }

        public async Task<IEnumerable<FridgeActivityLog>> GetLogs()
        {
            using var conn = _conn.GetSqlConnection(_connStrings.RefrigeratorDb.ConnectionString);
            var result = await conn.QueryAsync<FridgeActivityLog>(FridgeActivityLogSqlConstants.SelectLogs);
            return result;
        }
    }
}
