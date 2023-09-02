using Microsoft.AspNetCore.Mvc;
using Refrigerator.Api.Domain.Dto;
using Refrigerator.Api.Domain.Requests;
using Refrigerator.Api.Domain.Services;
using System.ComponentModel.DataAnnotations;

namespace Refrigerator.Api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly IFridgeActivityLogService _fridgeActivityLogService;
        private readonly IStockService _stockService;

        public FridgeController(IFridgeActivityLogService fridgeActivityLogService,
                                IStockService stockService)
        {
            _fridgeActivityLogService = fridgeActivityLogService;
            _stockService = stockService;
        }

        /// <summary>
        /// Get the current items in fridge.
        /// </summary>
        /// <returns></returns>
        [HttpGet("fridge/items")]
        public async Task<IEnumerable<FridgeItemsDto>> GetFridgeItems()
        {
            return await _fridgeActivityLogService.GetItems();
        }

        /// <summary>
        /// Get the fridge activity logs.
        /// </summary>
        /// <returns></returns>
        [HttpGet("fridge/logs")]
        public async Task<IEnumerable<FridgeActivityLogDto>> GetActivityLogs()
        {
            return await _fridgeActivityLogService.GetLogs();
        }

        /// <summary>
        /// Add purchased item into refrigerator. | For items reference, call the following endpoint: api/v1/product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("fridge/additem")]
        public async Task<IActionResult> AddPurchasedItem(AddItemRequest request)
        {
            if (request.ProductId <= 0 || request.Quantity <= 0)
                return BadRequest("Value must be greater than 0");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isAdded = await _stockService.AddItem(request);
            if (isAdded) return Ok("Item added successfully.");

            return BadRequest("Item could not be added");
        }

        /// <summary>
        /// Handles product consumption from the refrigerator. | For items reference, call the following endpoint: api/v1/product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("fridge/consume")]
        public async Task<IActionResult> ConsumeItem(ConsumeItemRequest request)
        {
            if (request.ProductId <= 0 || request.Quantity <= 0)
                return BadRequest("Invalid values");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isConsumed = await _stockService.ConsumeItem(request);
            if (isConsumed) return Ok("Item consumed successfully.");

            return BadRequest("Item could not be consumed");
        }

        /// <summary>
        /// Remove an item by stockId.
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        [HttpDelete("fridge/deleteitem")]
        public async Task<IActionResult> RemoveItem([Required]int stockId)
        {
            if (stockId <= 0)
                return BadRequest("Value must be greater than 0");

            var isDeleted = await _stockService.DeleteItem(stockId);
            if (isDeleted) return Ok("Item deleted successfully.");

            return BadRequest("Item could not be deleted.");
        }
    }
}
