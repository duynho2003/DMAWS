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
        public Task<List<Customers>> GetCustomerAsync()
        {
            //var res = await _db.Customers.Include(c=>c.Orders).ToListAsync();
            var res = _db.Customers.ToListAsync();
            //var res = _db.Customers.Include(c => c.Orders);
            //var res = from c in _db.Customers
            //          join o in _db.Orders
            //          on c.CustomerId equals o.CustomerId
            //          select new
            //          {
            //              Customers=c,
            //              Orders=o,
            //          };
            return res;
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
