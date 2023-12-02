using Kpi.Core.DTOs.Sprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Core.Services
{
    public interface ISprintService
    {
        Task<Models.Sprints.Sprint> AddSprintFromExcel(string filePath, int UserId, SprintDto model);
    }
}
