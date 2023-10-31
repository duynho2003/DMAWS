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
        public async Task<Orders> GetOrderAsync(int id)
        {
            return await _db.Orders.FindAsync(id);
        }

        //public List<Orders> Orders { get; set; }
        public async Task<List<Orders>> GetOrdersAsync(int? customerId)
        {

            if (customerId == null)
            {
                var model = await _db.Orders.Include(c => c.Customers)
              //.ThenInclude(o => o!.Orders)
              .OrderBy(i => i.OrderDate)
              //.AsNoTracking()
              .ToListAsync();
                return model;
            }
            else
            {
                var order = await _db.Orders.Include(c => c.Customers)
                   .Where(f => f.CustomerId == customerId).ToListAsync();
                return order;
            }
        }

        public async Task<bool> PostOrdersAsync(Orders newOrders)
        {
            await _db.Orders.AddAsync(newOrders);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
