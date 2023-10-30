using Lab05Lib;

namespace Lab05WebAPI.Repository
{
    public interface IUserRepository
    {
        Task<Users> checkLogin(string name, string password);
        Task<List<Users>> GetUsers();
        Task<Users> GetUser(int id);
        Task<bool> saveUser(Users newUser);
        Task<bool> updateUser(Users editUser);
        Task<bool> deleteUser(int id);
    }
}
