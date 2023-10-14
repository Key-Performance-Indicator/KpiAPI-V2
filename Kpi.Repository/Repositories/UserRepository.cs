using Kpi.Core.Models;
using Kpi.Core.Models.Users;
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
            await AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var user = await _context.Users.Where(x => x.Username == userName).FirstOrDefaultAsync();
            return user;
        }

        
    }
}
