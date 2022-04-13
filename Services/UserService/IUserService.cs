using Examination_WebApi.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Examination_WebApi.Services.AuthenticationService
{
    public interface IUserService
    {
        Task<bool> UserExistsAsync(string username);
        Task<ActionResult<ReadUser>> CreateUserAsync(CreateUser model);
        Task<ActionResult> VerifyUserAsync(AuthenticateUser model);
        Task<ActionResult> DeleteUserAsync(int id);
        Task<ActionResult<ReadUser>> GetUserAsync(string email);
    }
}
