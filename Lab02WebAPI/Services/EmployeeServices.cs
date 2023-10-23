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

        public async Task<Employee> DeleteEmployee(string id)
        {
            string query = "DELETE FROM Employee WHERE id=@id";
            using (var _db = db.setConnectDB())
            {
                await _db.OpenAsync(); // mở kết nối db
                var dp = new DynamicParameters();
                dp.Add("@id", id);
                return await _db.ExecuteScalarAsync<Employee>(query, dp);
            }
        }

        public async Task<Employee> GetEmployee(string id)
        {
            string query = "SELECT * FROM Employee WHERE id=@id";
            using (var _db = db.setConnectDB())
            {
                await _db.OpenAsync(); // mở kết nối db
                var dp = new DynamicParameters();
                dp.Add("@id", id);
                return await _db.QueryFirstOrDefaultAsync<Employee>(query, dp);
            }
        }

        public async Task<Employee> PostEmployee(Employee newEmployee)
        {
            string query = "INSERT INTO Employee VALUES(@id,@name,@phone)";
            using (var _db = db.setConnectDB())
            {
                await _db.OpenAsync(); // mở kết nối db
                var dp = new DynamicParameters();
                dp.Add("@id", newEmployee.id);
                dp.Add("@name", newEmployee.name);
                dp.Add("@phone", newEmployee.phone);
                return await _db.ExecuteScalarAsync<Employee>(query, dp);
            }
        }

        public async Task<Employee> PutEmployee(Employee editEmployee)
        {
            string query = "UPDATE Employee SET name=@name,phone=@phone,id=@id";
            using (var _db = db.setConnectDB())
            {
                await _db.OpenAsync(); // mở kết nối db
                var dp = new DynamicParameters();
                dp.Add("@name", editEmployee.name);
                dp.Add("@phone", editEmployee.phone);
                dp.Add("@id", editEmployee.id);
                return await _db.ExecuteScalarAsync<Employee>(query, dp);
            }
        }
    }
}
