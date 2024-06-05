using System.Runtime.InteropServices;
using System.Text.Json;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private User326037777Context _UsersContext;
        public UserRepository(User326037777Context UsersContext)
        {
            _UsersContext = UsersContext;
        }
        public async Task<User> GetById(int id)
        {
            return await _UsersContext.Users.FindAsync(id);
        }
        public async Task<User> Register(User user)
        {
            await _UsersContext.Users.AddAsync(user);
            await _UsersContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> Login(UserLogin userLogin)
        {
            return await _UsersContext.Users.Where(user => user.Email == userLogin.Email && user.Password == userLogin.Password).FirstOrDefaultAsync();
        }
        //public async Task<User> Update(int id, User userToUpdate)
        //{
        //    User user = await _UsersContext.Users.FindAsync(id);
        //    if (user == null)
        //        return null;
        //    userToUpdate.UserId = id;
        //    _UsersContext.Entry(user).CurrentValues.SetValues(userToUpdate);
        //    await _UsersContext.SaveChangesAsync();
        //    return user;
        //}

        public async Task<User> Update(int id, User user)
        {
            user.UserId = id;
            _UsersContext.Users.Update(user);
            await _UsersContext.SaveChangesAsync();
            return user;
        }

    }
}
