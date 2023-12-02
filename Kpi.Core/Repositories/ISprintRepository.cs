using Kpi.Core.Models.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Core.Repositories
{
    public interface ISprintRepository
    {
        Task<Sprint> AddNewSprint(Sprint sprint);
    }
}
