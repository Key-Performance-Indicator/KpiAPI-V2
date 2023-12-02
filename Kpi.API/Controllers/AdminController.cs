using Kpi.Core.DTOs.Users;
using Kpi.Core.Models;
using Kpi.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kpi.API.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
       
        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        #region UsersProcess
        [HttpPost("[action]")]
        public async Task<IActionResult> AddUserAsync(RegisterRequest registerRequest)
        {
            var res = await _userService.RegisterAsync(registerRequest);
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdUser(int id)
        {
            // only admins can access other user records
            var currentUser = (User)HttpContext.Items["User"];

            var user = await _userService.GetById(id);
            return Ok(user);
        }
        #endregion

        #region RolesProcess

        /// <summary>
        /// Role Update Add Metot
        /// </summary>
        /// <param name="role"></param>
        /// <returns>Role</returns>
        [HttpPost("[action]")]
        public async Task<IActionResult> AddUpdateRole(Role role)
        {
            var res = await _userService.AddUpdateRole(role);
            return Ok(res);
        }

        //public async Task<IActionResult> GetAl

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRolesListByUserId(int userId)
        {
            var userRoles = await _userService.GetRolesByUserID(userId);
            return Ok(userRoles);
        }

        [HttpPut("[action]")]
        //Role Id listesi ve userID ye göre role ekleme
        public async Task<IActionResult> AddRoleListUser(List<int> roleIdList, int userId)
        {
            var userRoles = await _userService.AddUserRoles(roleIdList, userId);
            return Ok(userRoles);
        }

        #endregion


        #region Project process



        #endregion
    }
}
