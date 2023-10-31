using Lab04;

namespace Lab04WebAPI.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customers>> GetCustomersAsync();
        Task<bool> PostCustomersAsync(Customers newCustomer);
    }
}
