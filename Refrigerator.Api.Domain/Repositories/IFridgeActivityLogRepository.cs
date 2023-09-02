using Refrigerator.Api.Domain.Models;

namespace Refrigerator.Api.Domain.Repositories
{
    public interface IFridgeActivityLogRepository
    {
        /// <summary>
        /// Get the complete logs for purchase and consumption activity 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FridgeActivityLog>> GetLogs();
    }
}
