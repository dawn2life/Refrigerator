using Refrigerator.Api.Domain.Models;
using Refrigerator.Api.Domain.Repositories;
using Refrigerator.Api.Domain.Services;

namespace Refrigerator.Api.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }
    }
}
