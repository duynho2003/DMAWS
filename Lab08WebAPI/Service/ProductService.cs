using Lab08WebAPI.Models;
using Lab08WebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lab08WebAPI.Service
{
    public class ProductService : IProductRepository
    {
        private readonly DmawsdbContext _db;
        public ProductService(DmawsdbContext db)
        {
            _db = db;
        }
        public async Task<Product> GetProduct(int id)
        {
            return await _db.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<bool> PostProduct(Product newProduct)
        {
            await _db.Products.AddAsync(newProduct);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
