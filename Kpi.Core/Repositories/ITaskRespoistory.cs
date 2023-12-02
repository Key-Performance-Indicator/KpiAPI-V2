using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Core.Repositories
{
    public interface ITaskRespoistory
    {
        Task<Models.Tasks.Task> AddTask(Models.Tasks.Task model);
    }
}
