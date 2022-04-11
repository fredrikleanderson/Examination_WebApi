using Examination_WebApi.Data;
using Examination_WebApi.Models.Entities;
using Examination_WebApi.Models.Users;
using Examination_WebApi.Services.AddressService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Examination_WebApi.Services.AuthenticationService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IAddressService _addressService;
        private readonly IConfiguration _configuration;

        public UserService(DataContext context, IAddressService addressService, IConfiguration configuration)
        {
            _context = context;
            _addressService = addressService;
            _configuration = configuration;
        }

        public async Task<ActionResult<ReadUser>> CreateUserAsync(CreateUser model)
        {
            if (await UserExistsAsync(model.Email))
            {
                return new ConflictObjectResult("A user with the same email already exists.");
            }

            UserEntity user = new UserEntity
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                AddressId = (await _addressService.FindOrCreateAddressAsync(model)).Id
            };
            user.CreatePassword(model.Password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new OkObjectResult (new ReadUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                StreetAddress = user.Address.StreetAddress,
                PostalCode = user.Address.PostalCode,
                City = user.Address.City
            });
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _context.Users.AnyAsync(x => x.Email == username);
        }

        public async Task<ActionResult> VerifyUserAsync(VerifyUser model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return new BadRequestObjectResult("Both email and password must be provided.");
            }

            UserEntity? user = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);

            if (user == null)
            {
                return new BadRequestObjectResult("Incorrect password or email.");
            }

            if (!user.CompareSecurePassword(model.Password))
            {
                return new BadRequestObjectResult("Incorrect password or email.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("UserKey", _configuration.GetValue<string>("UserKey"))
                }),

                Expires = DateTime.Now.AddDays(1),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("UserKey"))),
                    SecurityAlgorithms.HmacSha512Signature)
            };

            var accessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            return new OkObjectResult(accessToken);
        }
    }
}
