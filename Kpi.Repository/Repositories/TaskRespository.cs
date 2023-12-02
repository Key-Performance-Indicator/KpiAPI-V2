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
    public class TaskRespository : GenericRepository<Core.Models.Tasks.Task>,ITaskRespoistory
    {
        public TaskRespository(AppDbContext context) : base(context){
        
        }
        public async Task<Core.Models.Tasks.Task> AddTask(Core.Models.Tasks.Task model)
        {
            try
            {
                var res = _context.Tasks.AddAsync(model);
                await _context.SaveChangesAsync();
                return model;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

