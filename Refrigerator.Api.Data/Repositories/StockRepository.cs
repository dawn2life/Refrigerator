using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Refrigerator.Api.Data.DataAccess;
using Refrigerator.Api.Data.Infrastructure;
using Refrigerator.Api.Data.SqlConstants;
using Refrigerator.Api.Domain.Configurations;
using Refrigerator.Api.Domain.Models;
using Refrigerator.Api.Domain.Repositories;
using System.Data;

namespace Refrigerator.Api.Data.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly RefrigeratorContext _context;
        private readonly IConnection _conn;
        private readonly ConnectionStrings _connStrings;

        public StockRepository(RefrigeratorContext context, 
                               IOptions<ConnectionStrings> connStrings,
                               IConnection conn) 
        {
            _context = context;
            _conn = conn;
            _connStrings = connStrings.Value;
        }

        public async Task<List<Stock>> GetItems() 
        {
            using var conn = _conn.GetSqlConnection(_connStrings.RefrigeratorDb.ConnectionString);
            var result = await conn.QueryAsync<Stock>(StockSqlConstants.SelectStocks);
            return result.ToList();
        }

        public async Task<bool> AddItem(Stock stock, FridgeActivityLog activityLog)
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    _context.Stocks.Add(stock);
                    _context.FridgeActivityLogs.Add(activityLog);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<Stock> GetStockItem(int productId)
        {
            using var conn = _conn.GetSqlConnection(_connStrings.RefrigeratorDb.ConnectionString);
            var result = await conn.QuerySingleOrDefaultAsync<Stock>(
                StockSqlConstants.SelectStockById,
                new { ProductId = productId });

            return result;
        }

        public async Task<bool> UpdateStockItem(Stock stock, FridgeActivityLog activityLog)
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    _context.Stocks.Update(stock);
                    _context.FridgeActivityLogs.Add(activityLog);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<IEnumerable<Stock>> GetStockItemsToUpdateExpiration()
        {
            using var conn = _conn.GetSqlConnection(_connStrings.RefrigeratorDb.ConnectionString);
            var result = await conn.QueryAsync<Stock>(StockSqlConstants.SelectStockItemsToUpdateExpiration);
            return result;
        }

        public async Task<IEnumerable<Stock>> GetExpiredItems()
        {
            using var conn = _conn.GetSqlConnection(_connStrings.RefrigeratorDb.ConnectionString);
            var result = await conn.QueryAsync<Stock>(StockSqlConstants.SelectExpiredStocks);
            return result.ToList();
        }

        public async Task<bool> DeleteItem(int stockId) 
        {
            var stockItem = await _context.Stocks.FindAsync(stockId);
            if (stockItem == null) return false;

            _context.Stocks.Remove(stockItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
