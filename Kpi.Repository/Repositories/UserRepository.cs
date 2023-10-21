using Kpi.Core.Models;
using Kpi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
      
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> AddUserAsync(User user)
        {
            var res = _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            try
            {
                userName = userName.Trim();
                var user = await _context.Users.Where(x => x.Username == userName).FirstOrDefaultAsync();
                if (user == null)
                    return null;
                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        
    }
}
