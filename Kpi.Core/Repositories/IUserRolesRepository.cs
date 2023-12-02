using Kpi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Core.Repositories
{
    public interface IUserRolesRepository
    {
        Task<List<Role>> GetRolesListByUserId(int userId);
        Task<Role> AddUpdateRolesUser(Role role);
        Task<List<UserRoles>> AddUserRoles(List<int> roleIdList, int userId);

    }
}
