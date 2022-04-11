using Examination_WebApi.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace Examination_WebApi.Services.AuthenticationService
{
    public interface IUserService
    {
        Task<bool> UserExistsAsync(string username);
        Task<ActionResult<ReadUser>> CreateUserAsync(CreateUser model);
        Task<ActionResult> VerifyUserAsync(AuthenticateUser model);
    }
}
