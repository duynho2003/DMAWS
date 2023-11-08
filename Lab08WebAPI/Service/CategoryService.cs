using Lab08WebAPI.Models;
using Lab08WebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lab08WebAPI.Service
{
    public class CategoryService : ICategoryRepository
    {
        private readonly DmawsdbContext _db;
        public CategoryService(DmawsdbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _db.Categories.Include(p=>p.Products)
                        .OrderBy(c=>c.CategoryName).ToListAsync();
        }

        public async Task<bool> PostCategories(Category newCategories)
        {
            await _db.Categories.AddAsync(newCategories);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
