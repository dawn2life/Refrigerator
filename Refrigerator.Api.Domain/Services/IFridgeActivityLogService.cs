using Refrigerator.Api.Domain.Dto;
using Refrigerator.Api.Domain.Models;

namespace Refrigerator.Api.Domain.Services
{
    public interface IFridgeActivityLogService
    {
        /// <summary>
        /// Get the current items in fridge
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FridgeItemsDto>> GetItems();

        /// <summary>
        /// Get the logs for purchase and consumption activity 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FridgeActivityLogDto>> GetLogs();
    }
}
