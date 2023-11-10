using Lab09Lib;
using Lab09WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab09WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private IShipperRepository _shipperRepository;
        public ShippersController(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        [HttpGet()]
        public async Task<IEnumerable<Shipper>> Get() 
        {
            return await _shipperRepository.GetShippers();
        }

        [HttpPost()]
        public async Task<bool> Post(Shipper shipper)
        {
            return await _shipperRepository.PostShipper(shipper);
        }

        [HttpDelete()]
        public async Task<bool> Delete(int id)
        {
            return await _shipperRepository.DeleteShipper(id);
        }
    }
}
