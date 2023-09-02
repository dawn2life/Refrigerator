using Dapper;
using Microsoft.Extensions.Options;
using Refrigerator.Api.Data.Infrastructure;
using Refrigerator.Api.Data.SqlConstants;
using Refrigerator.Api.Domain.Configurations;
using Refrigerator.Api.Domain.Models;
using Refrigerator.Api.Domain.Repositories;

namespace Refrigerator.Api.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConnection _conn;
        private readonly ConnectionStrings _connStrings;

        public ProductRepository(IOptions<ConnectionStrings> connStrings,
                                           IConnection conn)
        {
            _conn = conn;
            _connStrings = connStrings.Value;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            using var conn = _conn.GetSqlConnection(_connStrings.RefrigeratorDb.ConnectionString);
            var result = await conn.QueryAsync<Product>(ProductSqlConstants.SelectProducts);
            return result;
        }

        public async Task<Product> GetProductById(int id) 
        {
            using var conn = _conn.GetSqlConnection(_connStrings.RefrigeratorDb.ConnectionString);
            var result = await conn.QueryFirstOrDefaultAsync<Product>(ProductSqlConstants.SelectProductById, new { Id = id });
            return result;
        }
    }
}
