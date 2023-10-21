using Kpi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Core.Authentications
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user, List<Role> roles);
        public int? ValidateJwtToken(string token);
    }
}
