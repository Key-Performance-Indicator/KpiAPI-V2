using Kpi.Core.Models.Sprints;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Core.Models.Projects
{
    public class Project : BaseEntity
    {
        public Project()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public int SprintId { get; set; }
        public Sprint Sprint { get; set; }

        public User User { get; set; }
    }
}
