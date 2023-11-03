using Kpi.Core.Models;
using Kpi.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Kpi.Core.DTOs.Users;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kpi.API.Controllers
{
 
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateRequest model)
        
        {
            var response = await _userService.Authenticate(model);
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest user)
        {
            var res = await _userService.RegisterAsync(user);
            return Ok(res);
        }


    }
}
