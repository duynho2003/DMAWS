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
        public IActionResult Get()
        {
            return Ok(_ordersRepository.GetOrdersAsync());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_ordersRepository.GetOrdersAsync(id));
        }

        [HttpPost]
        public IActionResult Post(Orders orders)
        {
            return Ok(_ordersRepository.PostOrdersAsync(orders));
        }
    }
}
