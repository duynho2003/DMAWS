using Lab08WebAPI.Models;
using Lab08WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab08WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Get() 
        {
            return await _categoryRepository.GetCategories();
        }
        [HttpPost]
        public async Task<bool> Post(Category categories)
        {
            return await _categoryRepository.PostCategories(categories);
        }
    }
}
