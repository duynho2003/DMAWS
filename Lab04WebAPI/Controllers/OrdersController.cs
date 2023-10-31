using Lab04;
using Lab04WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab04WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _ordersRepository;
        public OrdersController(IOrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        [HttpGet]
        public Task<List<Orders>> Get(int? customerId)
        {
            return _ordersRepository.GetOrdersAsync(customerId);
        }

        [HttpGet("{id}")]
        public Task<Orders> Get(int id)
        {
            return _ordersRepository.GetOrderAsync(id);
        }

        [HttpPost]
        public Task<bool> Post(Orders orders)
        {
            return _ordersRepository.PostOrdersAsync(orders);
        }
    }
}
