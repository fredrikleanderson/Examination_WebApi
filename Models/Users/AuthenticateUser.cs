namespace Examination_WebApi.Models.Users
{
    public class AuthenticateUser
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
