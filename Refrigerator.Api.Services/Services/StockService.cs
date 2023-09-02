using AutoMapper;
using Refrigerator.Api.Data.DataAccess;
using Refrigerator.Api.Domain.Dto;
using Refrigerator.Api.Domain.Enumerations;
using Refrigerator.Api.Domain.Models;
using Refrigerator.Api.Domain.Repositories;
using Refrigerator.Api.Domain.Requests;
using Refrigerator.Api.Domain.Services;

namespace Refrigerator.Api.Services.Services
{
    public class StockService : IStockService
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        private readonly IProductRepository _productRepository;
        private readonly RefrigeratorContext _context;

        public StockService(IMapper mapper,
                            IStockRepository stockRepository,
                            IProductRepository productRepository,
                            RefrigeratorContext refrigeratorContext)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
            _productRepository = productRepository;
            _context = refrigeratorContext; 
        }

        public async Task<bool> AddItem(AddItemRequest request)
        {
            var products = await _productRepository.GetProducts();
            var stock = _mapper.Map<Stock>(request);
            var item = products.FirstOrDefault(p => p.Id == stock.ProductId);

            if (item == null) return false;

            var isItemExpired = DateTime.Now.CompareTo(item.ExpirationDate);

            if (isItemExpired > 0)
                stock.IsExpired = true;
            else
                stock.IsExpired = false;

            stock.PurchaseDate = DateTime.Now;
            var activityHistory = _mapper.Map<FridgeActivityLog>(stock);
            activityHistory.Type = ActivityType.PURCHASE;

            return await _stockRepository.AddItem(stock, activityHistory);
        }

        public async Task<bool> ConsumeItem(ConsumeItemRequest request)
        {
            var stockItem = await _stockRepository.GetStockItem(request.ProductId);

            if (stockItem == null || stockItem.Quantity < request.Quantity || stockItem.IsExpired)
                return false;

            stockItem.Quantity -= request.Quantity;
            var consumptionLog = new FridgeActivityLog
            {
                ProductId = request.ProductId,
                Quantity = -request.Quantity,
                Type = ActivityType.CONSUMPTION,
                ActivityDate = DateTime.Now
            };

            return await _stockRepository.UpdateStockItem(stockItem, consumptionLog);
        }

        public async Task<bool> UpdateStockItemExpiration()
        {
            var stockItemsToUpdate = await _stockRepository.GetStockItemsToUpdateExpiration();

            foreach (var stockItem in stockItemsToUpdate)
            {
                var product = await _productRepository.GetProductById(stockItem.ProductId);
                var isExpired = DateTime.Now > product.ExpirationDate;

                stockItem.IsExpired = isExpired;
                _context.Stocks.Update(stockItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ExpiredItemDto>> GetExpiredItems() 
        {
            var expiredItem = await _stockRepository.GetExpiredItems();
            return _mapper.Map<IEnumerable<ExpiredItemDto>>(expiredItem);
        }

        public async Task<bool> DeleteItem(int stockId) 
        {
            return await _stockRepository.DeleteItem(stockId);
        }
    }
}
