using Lab09Lib;
using Lab09WebAPI.Db_Helper;
using Lab09WebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lab09WebAPI.Service
{
    public class ShipperService : IShipperRepository
    {
        private readonly DatabaseContext _db;
        public ShipperService(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<bool> DeleteShipper(int id)
        {
            var shipper = await _db.Shipper.SingleOrDefaultAsync(s=>s.id.Equals(id));
            if (shipper != null)
            {
                _db.Shipper.Remove(shipper);
                await _db.SaveChangesAsync();
                return true;
            }
            else 
            {
                return false;
            }
        }

        public async Task<IEnumerable<Shipper>> GetShippers()
        {
            return await _db.Shipper.ToListAsync();
        }

        public async Task<bool> PostShipper(Shipper shipper)
        {
            await _db.Shipper.AddAsync(shipper);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
