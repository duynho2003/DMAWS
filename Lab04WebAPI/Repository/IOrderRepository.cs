using Lab04;

namespace Lab04WebAPI.Repository
{
    public interface IOrderRepository
    {
        Task<List<Orders>> GetOrdersAsync();
        Task<Orders> GetOrdersAsync(int id);
        Task<bool> PostOrdersAsync(Orders newOrders);
    }
}
