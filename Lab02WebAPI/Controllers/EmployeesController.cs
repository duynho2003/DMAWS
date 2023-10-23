using Lab02Lib;
using Lab02WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab02WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServices _services;

        public EmployeesController(IEmployeeServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _services.GetEmployees();
        }

        [HttpGet("{id}")]
        public async Task<Employee> GetEmployees(string id)
        {
            return await _services.GetEmployee(id);
        }
        [HttpPost()]
        public async Task<Employee> PostEmployees(Employee newEmyploee)
        {
            return await _services.PostEmployee(newEmyploee);
        }

        [HttpPut()]
        public async Task<Employee> PutEmployee(Employee editEmployee)
        {
            return await _services.PutEmployee(editEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<Employee> DeleteEmployee(string id)
        {
            return await _services.DeleteEmployee(id);
        }
    }
}
