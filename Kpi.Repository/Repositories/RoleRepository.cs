using Kpi.Core.Models;
using Kpi.Core.Repositories;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Repository.Repositories
{
    public class RoleRepository : GenericRepository<Role> , IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
          
        }
        public async Task<Role> AddUpdateRoles(Role role)
        {
            if(role.Id == 0)
            {
                _context.Roles.Add(role);
            }      
            else
            {
               var existingRole = await _context.Roles
                                     .FirstOrDefaultAsync(r => r.Id == role.Id);
                existingRole.RoleName = role.RoleName;
                _context.Roles.Update(existingRole);
            }
            await _context.SaveChangesAsync();
            return role;
        }

    }
}
