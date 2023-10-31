using Lab04;
using Lab04WebAPI.DB_Helper;
using Lab04WebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lab04WebAPI.Service
{
    public class CustomerServices : ICustomerRepository
    {
        private DatabaseContext _db;
        public CustomerServices(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<List<Customers>> GetCustomersAsync()
        {
            return await _db.Customers.Include(i => i.Orders)
                           .OrderBy(c => c.CustomerName).ToListAsync();//eager loading
        }

        public async Task<bool> PostCustomersAsync(Customers newCustomer)
        {
            var customer = _db.Customers.FirstOrDefaultAsync(
                    c=>c.CustomerId.Equals(newCustomer.CustomerId));
            if (customer == null)
            {
                await _db.Customers.AddAsync(newCustomer);
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
