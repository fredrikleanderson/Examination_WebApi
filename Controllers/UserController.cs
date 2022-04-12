using Examination_WebApi.Data;
using Examination_WebApi.Models.Users;
using System.Web;
using Examination_WebApi.Services.AuthenticationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Examination_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<ReadUser>> SignUp(CreateUser model)
        {
            return await _userService.CreateUserAsync(model);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(AuthenticateUser model)
        {
            return await _userService.VerifyUserAsync(model);
        }

        [HttpGet("CurrentUser")]
        [Authorize(Roles = "User, Admin")]
        public async Task<ActionResult<ReadUser>> CurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                return await _userService.GetUserAsync(identity);
            }

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return await _userService.DeleteUserAsync(id);
        }
    }
}
