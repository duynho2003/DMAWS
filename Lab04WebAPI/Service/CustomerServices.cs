using Lab04;
using Lab04WebAPI.Repository;

namespace Lab04WebAPI.Service
{
    public class CustomerServices : ICustomerRepository
    {
        public Task<List<Customers>> GetCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> PostCustomersAsync(Customers newCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
