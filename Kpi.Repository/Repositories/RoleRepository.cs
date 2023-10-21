using Kpi.Core.Models;
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
    public class RoleRepository : GenericRepository<Role> 
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
          
        }
        
    }
}
