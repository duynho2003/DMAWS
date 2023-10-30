using Lab04;
using Lab04WebAPI.DB_Helper;
using Lab04WebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lab04WebAPI.Service
{
    public class OrderServices : IOrderRepository
    {
        private DatabaseContext _db;
        public OrderServices(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<Orders> GetOrdersAsync(int id)
        {
            return await _db.Orders.FindAsync(id);
        }

        public async Task<List<Orders>> GetOrdersAsync()
        {
            return await _db.Orders.ToListAsync();
        }

        public async Task<bool> PostOrdersAsync(Orders newOrders)
        {
            await _db.Orders.AddAsync(newOrders);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
