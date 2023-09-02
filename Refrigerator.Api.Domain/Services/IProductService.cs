using Refrigerator.Api.Domain.Models;

namespace Refrigerator.Api.Domain.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Get Products.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProducts();
    }
}
