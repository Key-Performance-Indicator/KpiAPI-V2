using Kpi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Core.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> AddUpdateRoles(Role role);
    }
}
