using Lab02Lib;

namespace Lab02WebAPI.Repository
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string id);
        Task<Employee> PostEmployee(Employee newEmployee);
        Task<Employee> PutEmployee(Employee editEmployee);
        Task<Employee> DeleteEmployee(string id);
    }
}
