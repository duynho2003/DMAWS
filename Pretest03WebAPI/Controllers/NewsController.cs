using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pretest03WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Pretest03WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsDbContext _db;
        public NewsController(NewsDbContext db)
        {
            _db = db;
        }

        [HttpGet()]
        public async Task<IEnumerable<TbNews>> GetNews()
        {
            return await _db.TbNews.ToListAsync();
        }

        [HttpPost()]
        public async Task<bool> PostNews (TbNews newNews)
        {
            var news = await _db.TbNews.FirstOrDefaultAsync(e => e.NewsId.Equals(newNews.NewsId));
            if (news == null)
            {
                await _db.TbNews.AddAsync(newNews);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpDelete("{NewsId}")]
        public async Task<bool> DeleteNews (string NewsId)
        {
            var dnews = await _db.TbNews.SingleOrDefaultAsync(s => s.NewsId.Equals(NewsId));
            if (dnews != null)
            {
                _db.TbNews.Remove(dnews);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
