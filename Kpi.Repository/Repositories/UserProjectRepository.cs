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
    public class UserProjectRepository : GenericRepository<UserProjectRepository>, IUserProjectRepository
    {
        public UserProjectRepository(AppDbContext context) : base(context)
        {
        }

    }
}
