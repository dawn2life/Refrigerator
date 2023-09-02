using Refrigerator.Api.Domain.Dto;
using Refrigerator.Api.Domain.Models;
using Refrigerator.Api.Domain.Requests;

namespace Refrigerator.Api.Domain.Services
{
    public interface IStockService
    {
        /// <summary>
        /// Add item into stock
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> AddItem(AddItemRequest request);

        /// <summary>
        /// Consumes a specified quantity of a product.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> ConsumeItem(ConsumeItemRequest request);

        /// <summary>
        /// Update stock items' expiration status based on product expiration dates.
        /// </summary>
        /// <returns></returns>
        Task<bool> UpdateStockItemExpiration();

        /// <summary>
        /// Get expired Stock.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ExpiredItemDto>> GetExpiredItems();

        /// <summary>
        /// Delete an item by stockId.
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        Task<bool> DeleteItem(int stockId);
    }
}
