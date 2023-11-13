using Lab10WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab10WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DmawsdbContext _db;
        public EmployeesController(DmawsdbContext db)
        {
            _db = db;
        }

        [HttpGet()]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _db.Employees.Where(e => e.Roles!.Equals("Users")).ToListAsync();
        }
        
        [HttpPost()]
        public async Task<bool> PostEmployee(Employee newEmployee)
        {
            var employee= await _db.Employees.FirstOrDefaultAsync(e=>e.Code.Equals(newEmployee.Code));
            if (employee == null)
            {
                await _db.Employees.AddAsync(newEmployee);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet("{code}/{pass}")]
        public async Task<Employee> checkLogin(string code, string pass)
        {
            var employee = await _db.Employees.FirstOrDefaultAsync(e => e.Code.Equals(code));
            if (employee != null) 
            {
                if (employee!.Password!.Equals(pass))
                {
                    return employee;
                }
                else
                {
                    return null!;
                }
            }
            else 
            {
                return null!;
            }
        }

        [HttpPut("{code}")]
        public async Task<bool> Resetpassword(string code)
        {
            var employee = await _db.Employees.FirstOrDefaultAsync(e => e.Code.Equals(code));
            if (employee != null)
            {
                employee.Password = "Password@123";
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }    
}
