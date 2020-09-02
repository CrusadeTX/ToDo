using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.API.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<User> AddUser(User user)
        {
           var result =  await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> DeleteUser(int userId)
        {
            var result = await appDbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (result != null)
            {
                appDbContext.Users.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<User> GetUser(int userId)
        {
            return await appDbContext.Users.Include(u => u.ToDos).FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await appDbContext.Users.Include(u => u.ToDos).ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await appDbContext.Users
                .FirstOrDefaultAsync(u => u.UserId == user.UserId);

            if (result != null)
            {
                result.FName = user.FName;
                result.LName = user.LName;
                result.Email = user.Email;
                result.Password = user.Password;
                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
