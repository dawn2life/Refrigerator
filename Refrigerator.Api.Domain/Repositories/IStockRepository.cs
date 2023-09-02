using Refrigerator.Api.Domain.Models;
using Refrigerator.Api.Domain.Requests;

namespace Refrigerator.Api.Domain.Repositories
{
    public interface IStockRepository
    {
        /// <summary>
        /// Get current stock.
        /// </summary>
        /// <returns></returns>
        Task<List<Stock>> GetItems();

        /// <summary>
        /// Add an item into stock.
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="activityLog"></param>
        /// <returns></returns>
        Task<bool> AddItem(Stock stock, FridgeActivityLog activityLog);

        /// <summary>
        /// Get stock by productId.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<Stock> GetStockItem(int productId);

        /// <summary>
        /// Update stock and fridge activity log.
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="activityLog"></param>
        /// <returns></returns>
        Task<bool> UpdateStockItem(Stock stock, FridgeActivityLog activityLog);

        /// <summary>
        /// Retrieve stock items that need their expiration status updated.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Stock>> GetStockItemsToUpdateExpiration();

        /// <summary>
        /// Get expired stock.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Stock>> GetExpiredItems();

        /// <summary>
        /// Delete an item by stockId.
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        Task<bool> DeleteItem(int stockId);
    }
}
