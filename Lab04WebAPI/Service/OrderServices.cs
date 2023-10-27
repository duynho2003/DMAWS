using Lab04;
using Lab04WebAPI.Repository;

namespace Lab04WebAPI.Service
{
    public class OrderServices : IOrderRepository
    {
        public Task<List<Orders>> GetOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Orders> GetOrdersAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PostOrdersAsync(Orders newOrders)
        {
            throw new NotImplementedException();
        }
    }
}
