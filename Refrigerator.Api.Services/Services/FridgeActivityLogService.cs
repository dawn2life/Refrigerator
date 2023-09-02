using AutoMapper;
using Refrigerator.Api.Domain.Dto;
using Refrigerator.Api.Domain.Models;
using Refrigerator.Api.Domain.Repositories;
using Refrigerator.Api.Domain.Services;

namespace Refrigerator.Api.Services.Services
{
    public class FridgeActivityLogService : IFridgeActivityLogService
    {
        private readonly IMapper _mapper;
        private readonly IFridgeActivityLogRepository _fridgeActivityLogRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IProductRepository _productRepository;

        public FridgeActivityLogService(IFridgeActivityLogRepository fridgeActivityLogRepository,
                                        IMapper mapper,
                                        IStockRepository stockRepository,
                                        IProductRepository productRepository)
        {
            _fridgeActivityLogRepository = fridgeActivityLogRepository;
            _mapper = mapper;
            _stockRepository = stockRepository;
            _productRepository = productRepository;

        }

        public async Task<IEnumerable<FridgeItemsDto>> GetItems()
        {
            var currentStock = await _stockRepository.GetItems();
            var products = await _productRepository.GetProducts();

            var groupedFridgeItems = currentStock
                .Where(stock => !stock.IsExpired)
                .Join(products, stock => stock.ProductId, product => product.Id, (stock, product) => new
                {
                    ProductName = product.Name,
                    Quantity = stock.Quantity
                })
                .GroupBy(item => item.ProductName)
                .Select(group => new FridgeItemsDto
                {
                    ProductName = group.Key,
                    Quantity = group.Sum(item => item.Quantity)
                });

            return groupedFridgeItems;
        }

        public async Task<IEnumerable<FridgeActivityLogDto>> GetLogs()
        {
            var activityLog =  await _fridgeActivityLogRepository.GetLogs();
            return _mapper.Map<IEnumerable<FridgeActivityLogDto>>(activityLog);
        }
    }
}
