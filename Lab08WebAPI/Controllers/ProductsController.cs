using Lab08WebAPI.Models;
using Lab08WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab08WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productRepository.GetProducts();
        }
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _productRepository.GetProduct(id);
        }
        [HttpPost]
        public async Task<bool> Post(Product product)
        {
            return await _productRepository.PostProduct(product);
        }
    }
}
