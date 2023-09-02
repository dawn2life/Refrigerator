using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refrigerator.Api.Domain.Dto;
using Refrigerator.Api.Domain.Models;
using Refrigerator.Api.Domain.Services;

namespace Refrigerator.Api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get products.
        /// </summary>
        /// <returns></returns>
        [HttpGet("product")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productService.GetProducts();
        }
    }
}
