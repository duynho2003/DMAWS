using Lab09Lib;

namespace Lab09WebAPI.Repository
{
    public interface IUserRepository
    {
        Task<Users> checkLogin(string username, string password);
        Task<bool> PostUser (Users newUser);
    }
}
