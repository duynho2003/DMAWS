using Lab05Lib;
using Lab05WebAPI.DB_Helper;
using Lab05WebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lab05WebAPI.Services
{
    public class UserServices : IUserRepository
    {
        private DatabaseContext _db;
        public UserServices(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<Users> checkLogin(string name, string password)
        {
            var user= await _db.Users.SingleOrDefaultAsync(u => u.Name! == name);
            if(user!=null)
            {
                if(user.Password! == password)
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

        public async Task<bool> deleteUser(int id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(u => u.Id!.Equals(id));
            if (user!=null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
                return true;
            }
            else 
            { 
                return false; 
            } 
        }

        public async Task<Users> GetUser(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<List<Users>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<bool> saveUser(Users newUser)
        {
            await _db.Users.AddAsync(newUser);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> updateUser(Users editUser)
        {
            var user = await _db.Users.SingleOrDefaultAsync(
                u => u.Id.Equals(editUser.Id));
            if (user!=null)
            {
                user.Address = editUser.Address;
                user.Email = editUser.Email;
                user.Phone = editUser.Phone;
                user.Role = editUser.Role;
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
