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

        [HttpPost("[action]")]
        public async Task<IActionResult> AddUserAsync(RegisterRequest registerRequest)
        {
            var res = await _userService.RegisterAsync(registerRequest);
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            // only admins can access other user records
            var currentUser = (User)HttpContext.Items["User"];

            var user = await _userService.GetById(id);
            return Ok(user);
        }
    }
}
