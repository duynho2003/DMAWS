using Lab08WebAPI.Models;

namespace Lab08WebAPI.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<bool> PostCategories(Category newCategories);
    }
}
