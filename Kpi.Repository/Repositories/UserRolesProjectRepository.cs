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
    public class UserRolesProjectRepository : GenericRepository<UserRolesProjectRepository>, IUserRolesProjectRepository
    {
        public UserRolesProjectRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<List<Role>> GetByRolesByUserId(int userId)
        {
            var userRoles = await _context.UserRolesProject
                    .Where(urp => urp.UserId == userId)
                    .Select(urp => urp.Role)
                    .ToListAsync();

            return userRoles;
        }
    }
}
