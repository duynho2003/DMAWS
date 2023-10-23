using Dapper;
using Lab02Lib;
using Lab02WebAPI.Db_Helper;
using Lab02WebAPI.Repository;

namespace Lab02WebAPI.Services
{
    public class EmployeeServices : IEmployeeServices
    {

        private readonly DatabaseContext db=new DatabaseContext();

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            string query = "SELECT * FROM Employee";
            using (var _db=db.setConnectDB()) 
            {
                await _db.OpenAsync(); // mở kết nối db
                return await _db.QueryAsync<Employee>(query, _db);
            }
        }

        public Task<Employee> DeleteEmployee(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployee(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> PostEmployee(Employee newEmployee)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> PutEmployee(Employee editEmployee)
        {
            throw new NotImplementedException();
        }
    }
}
