using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Core.Models
{
    public class Role : BaseEntity
    {
       public string RoleName { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }

    }
}
