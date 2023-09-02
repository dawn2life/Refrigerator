using Refrigerator.Api.Domain.Models;

namespace Refrigerator.Api.Domain.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProducts();

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProductById(int id);
    }
}
