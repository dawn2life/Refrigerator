using Microsoft.AspNetCore.Mvc;
using Refrigerator.Api.Domain.Dto;
using Refrigerator.Api.Domain.Services;

namespace Refrigerator.Api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class ItemLifecycleController : ControllerBase
    {
        private readonly IStockService _stockService;

        public ItemLifecycleController(IStockService stockService)
        {
            _stockService = stockService;
        }

        /// <summary>
        /// Get expired stock items. | Note : Before geting the expired items always call api/v1/itemlifecycle/update-expiration
        /// </summary>
        /// <returns></returns>
        [HttpGet("itemlifecycle/expired-items")]
        public async Task<IEnumerable<ExpiredItemDto>> GetExpiredStockItems()
        {
            return await _stockService.GetExpiredItems();
        }

        /// <summary>
        /// Update stock items expiration status.
        /// </summary>
        /// <returns></returns>
        [HttpPut("itemlifecycle/update-expiration")]
        public async Task<IActionResult> UpdateStockItemExpiration()
        {
            var updateResult = await _stockService.UpdateStockItemExpiration();
            if (updateResult) return Ok("Stock items expiration updated successfully.");

            return BadRequest("Failed to update stock items' expiration.");
        }

    }
}
