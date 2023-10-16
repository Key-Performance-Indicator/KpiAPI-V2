using Kpi.Core.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Core.Models.Sprints
{
    public class Sprint
    {

        public Sprint()
        {

            Id = Guid.NewGuid();

        }
        public Guid Id { get; set; }
        public string SprintName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Project> Projects { get; set; }

        public IList<Tasks.Task>? Tasks { get; set; }
        public string DokumentUri { get; set; } = string.Empty;

    }

}
