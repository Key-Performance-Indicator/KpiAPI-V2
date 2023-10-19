using Kpi.Core.Models.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Core.Models
{
    public class UserRolesProject
    {
        [Key]            
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
             
    }
}
