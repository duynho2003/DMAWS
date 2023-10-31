using Lab04;

namespace Lab04WebAPI.Repository
{
    public interface IOrderRepository
    {
        Task<List<Orders>> GetOrdersAsync(int? customerId);
        Task<Orders> GetOrderAsync(int id);
        Task<bool> PostOrdersAsync(Orders newOrders);
    }
}
