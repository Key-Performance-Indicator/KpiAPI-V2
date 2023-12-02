using Kpi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Core.Services
{
    public interface ITaskService
    {
        Task<Core.Models.Tasks.Task> AddNewTask(string excelFilePath, int SprintId, int UserId);
    }
}
