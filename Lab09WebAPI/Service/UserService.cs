using Lab09Lib;
using Lab09WebAPI.Db_Helper;
using Lab09WebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lab09WebAPI.Service
{
    public class UserService : IUserRepository
    {
        private readonly DatabaseContext _db;
        public UserService(DatabaseContext db) 
        {
            _db = db;
        }
        public async Task<Users> checkLogin(string username, string password)
        {
            var user = await _db.Users.SingleOrDefaultAsync(
                                u=>u.username!.Equals(username));
            if (user != null)
            {
                if (user.password!.Equals(password))
                {
                    return user;
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

        public async Task<bool> PostUser(Users newUser)
        {
            var user = await _db.Users.SingleOrDefaultAsync(
                    u => u.username!.Equals(newUser.username));
            if (user == null) 
            {
                await _db.Users.AddAsync(newUser);
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
