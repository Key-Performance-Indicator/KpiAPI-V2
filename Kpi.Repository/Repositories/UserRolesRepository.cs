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
    public class UserRolesRepository : GenericRepository<UserRolesRepository>, IUserRolesRepository
    {
        public UserRolesRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<List<Role>> GetRolesListByUserId(int userId)
        {
            var userRoles = await _context.UserRoles
                    .Where(urp => urp.UserId == userId)
                    .Select(urp => urp.Role)
                    .ToListAsync();

            return userRoles;
        }

        public async Task<Role> AddUpdateRolesUser(Role role)
        {
            var existingRole = await _context.Roles
                                       .FirstOrDefaultAsync(r => r.Id == role.Id);
            if (existingRole == null)
            {
                _context.Roles.Add(role);
            }
            else
            {
                existingRole.RoleName = role.RoleName;
                _context.Roles.Update(existingRole);
            }
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<List<UserRoles>> AddUserRoles(List<int> roleIdList, int userId)
        {
            var existingUserRoles = await _context.UserRoles
                .Where(urp => urp.UserId == userId)
                .ToListAsync();
            _context.UserRoles.RemoveRange(existingUserRoles);

            foreach(var roleId in roleIdList)
            {
                var userRole = new UserRoles
                {
                    UserId = userId,
                    RoleId = roleId,
                };
                _context.UserRoles.AddAsync(userRole);
            }
            await _context.SaveChangesAsync();

            var userRoles = await _context.UserRoles.Where(urp => urp.UserId == userId) .ToListAsync();

            return userRoles;
        }
    }
}
