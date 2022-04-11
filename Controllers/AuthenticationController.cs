using Examination_WebApi.Data;
using Examination_WebApi.Models.Users;
using Examination_WebApi.Services.AuthenticationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examination_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _authenticationService;

        public AuthenticationController(IUserService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<ReadUser>> SignUp(CreateUser model)
        {
            return await _authenticationService.CreateUserAsync(model);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(VerifyUser model)
        {
            return await _authenticationService.VerifyUserAsync(model);
        }
    }
}
