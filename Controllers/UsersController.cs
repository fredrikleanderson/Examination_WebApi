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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
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

        [HttpPost]
        [Authorize(Roles ="Admin, User")]
        public async Task<ActionResult<ReadUser>> CurrentUser(AuthenticateUser user)
        {
            if (user != null)
            {
                return await _userService.GetUserAsync(user.Email);
            }

            return new NotFoundObjectResult("No user found");
        }

        [HttpGet]
        [Authorize(Roles ="Admin, User")]
        public async Task<ActionResult<ReadUser>> CurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string? email = identity?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (email != null)
            {
                return await _userService.GetUserAsync(email);
            }

            return new NotFoundObjectResult("No user found");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin, User")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return await _userService.DeleteUserAsync(id);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUser model)
        {
            return await _userService.UpdateUser(id, model);
        }

    }
}
