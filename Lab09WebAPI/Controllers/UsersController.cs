using Lab09Lib;
using Lab09WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab09WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        [HttpGet("{uname}/{upass}")]
        public async Task<Users> checkLogin(string uname, string upass) 
        {
            return await _userRepository.checkLogin(uname, upass);
        }

        [HttpPost()]
        public async Task<bool> PostUser(Users user)
        {
            return await _userRepository.PostUser(user);
        }
    }
}
