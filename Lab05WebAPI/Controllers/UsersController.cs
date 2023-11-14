using Lab05Lib;
using Lab05WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab05WebAPI.Controllers
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

        [HttpGet("{name}/{password}")]
        public async Task<Users> Login(string name, string password)
        {
            return await _userRepository.checkLogin(name, password);
        }

        [HttpGet("{id}")]
        public async Task<Users> Get(int id)
        {
            return await _userRepository.GetUser(id);
        }

        [HttpGet]
        public async Task<List<Users>> Get()
        {
            return await _userRepository.GetUsers();
        }

        [HttpPost]
        public async Task<bool> Post(Users newUser)
        {
            return await _userRepository.saveUser(newUser);
        }

        [HttpPut]
        public async Task<bool> Put(Users editUser)
        {
            return await _userRepository.updateUser(editUser);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _userRepository.deleteUser(id);
        }
    }
}
