using Kpi.Core.Models.Sprints;
using Kpi.Core.Repositories;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Repository.Repositories
{
    public class SprintRepository : GenericRepository<Sprint>,ISprintRepository
    {
        public SprintRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Sprint> AddNewSprint(Sprint sprint)
        {
            try
            {
                var res = _context.Sprints.AddAsync(sprint);
                await _context.SaveChangesAsync();
                return sprint;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
