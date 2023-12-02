using Kpi.Core.Models.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Core.Models.Tasks
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int RemainingWork { get; set; }

        public int? SprintId { get; set; }
        public Sprint Sprint { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int RemainingWork { get; set; } = 5;
        public string AssignedTo { get; set; }
 

        public int State { get; set; }
        public DateTime ClosedDate { get; set; }


        public Enums.Tag Tag { get; set; }
    }
}

