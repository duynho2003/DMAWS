using Lab04;

namespace Lab04WebAPI.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customers>> GetCustomerAsync();
        Task<bool> PostCustomersAsync(Customers newCustomer);
    }
}
