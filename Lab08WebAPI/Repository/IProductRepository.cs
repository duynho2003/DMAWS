using Lab08WebAPI.Models;

namespace Lab08WebAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<bool> PostProduct(Product newProduct);
    }
}
