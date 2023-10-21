using Kpi.Core.Models.Sprints;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Core.Models.Projects
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }

        [ForeignKey(nameof(Sprint))]
        public int? SprintId { get; set; }
        public Sprint Sprint { get; set; }

        public ICollection<UserRolesProject> UserRolesProjects { get; set; }
    }

    //public class Project : BaseEntity
    //{
    //    public Project()
    //    {
    //        Id = Guid.NewGuid();
    //    }
    //    public Guid Id { get; set; }
    //    public string ProjectName { get; set; }
    //    public Guid SprintId { get; set; }
    //    public Sprint Sprint { get; set; }

    //    public User User { get; set; }
    //}
}
