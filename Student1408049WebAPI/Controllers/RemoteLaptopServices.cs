using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student1408049WebAPI.Models;

namespace Student1408049WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoteLaptopServices : ControllerBase
    {
        private readonly StoreDbContext _db;
        public RemoteLaptopServices(StoreDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Laptop>> GetLaptopList()
        {
            return await _db.Laptops.ToListAsync();
        }

        [HttpPost()]
        public async Task<bool> PostLaptop(Laptop newLaptop)
        {
            var laptop = await _db.Laptops.FirstOrDefaultAsync(e => e.LaptopId.Equals(newLaptop.LaptopId));
            if (laptop == null)
            {
                await _db.Laptops.AddAsync(newLaptop);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpDelete("{code}")]
        public async Task<bool> DeleteLaptop(int code)
        {

            var lap = await _db.Laptops.SingleOrDefaultAsync(e => e.LaptopId == code);
            if (lap != null)
            {
                _db.Laptops.Remove(lap);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
