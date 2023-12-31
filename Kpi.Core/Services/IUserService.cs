﻿using Kpi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kpi.Core.DTOs.Users;

namespace Kpi.Core.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<List<Core.Models.User>> GetAll();
        Task<Core.Models.User> GetById(int id);
        Task<Core.Models.User> RegisterAsync(RegisterRequest model);
        Task<Role> AddUpdateRole(Role role);
        Task<Role> AddUpdateRoleUser(Role role);
        Task<List<Role>> GetRolesByUserID(int userId);
        Task<List<UserRoles>> AddUserRoles(List<int> roleIdList, int userId);
    }
}
