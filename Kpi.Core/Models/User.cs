﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kpi.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
       // public string AvatarLink { get; set; }
        public ICollection<UserProject> UserProject { get; set; }   
        public ICollection<UserRoles> UserRoles { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
