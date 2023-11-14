using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pretest01WebAPI.Models;

namespace Pretest01WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _db;
        public EmployeesController(EmployeeDbContext db)
        {
            _db = db;
        }

        [HttpGet("{EmpId}/{pass}")]
        public async Task<TblEmp> checkLogin(string EmpId, string pass)
        {
            var employee = await _db.TblEmps.FirstOrDefaultAsync(e => e.EmpId.Equals(EmpId));
            if (employee != null)
            {
                if (employee.Password!.Equals(pass))
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

        [HttpGet()]
        public async Task<IEnumerable<TblEmp>> findAll()
        {
            return await _db.TblEmps.ToListAsync();
        }

        [HttpPost()]
        public async Task<bool> PostEmployee(TblEmp newEmp)
        {
            var emp = await _db.TblEmps.FirstOrDefaultAsync(e => e.EmpId.Equals(newEmp.EmpId));
            if (emp == null)
            {
                await _db.TblEmps.AddAsync(newEmp);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPut()]
        public async Task<bool> updateSalary(TblEmp upemp)
        {
            var emp = await _db.TblEmps.SingleOrDefaultAsync(u => u.EmpId.Equals(upemp.EmpId));
            if (emp != null) 
            {
                emp.Salary = upemp.Salary;
                await _db.SaveChangesAsync();
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {

            var emp = await _db.TblEmps.SingleOrDefaultAsync(e => e.EmpId == id);
            if (emp != null)
            {
                _db.TblEmps.Remove(emp);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
