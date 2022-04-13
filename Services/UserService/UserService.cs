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
                Role = model.Role,
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
                Role = user.Role,
                StreetAddress = user.Address.StreetAddress,
                PostalCode = user.Address.PostalCode,
                City = user.Address.City
            });
        }

        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            UserEntity? user = await _context.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return new BadRequestResult();
            }

            int adressId = user.AddressId;

            user.FirstName = "Borttagen";
            user.LastName = "Borttagen";
            user.Role = "Deleted";
            user.Email = Guid.NewGuid().ToString();
            user.Address = await _addressService.FindOrCreateAddressAsync(new CreateUser
            {
                StreetAddress = "Borttagen",
                PostalCode = "00000",
                City = "Borttagen"
            });

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            await _addressService.RemoveEmptyAddressesAsync(adressId);

            return new NoContentResult();
        }

        public async Task<ActionResult<ReadUser>> GetUserAsync(string email)
        {
            UserEntity? user = await _context.Users.Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return new NotFoundResult();
            }

            return new ReadUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                StreetAddress = user.Address.StreetAddress,
                PostalCode = user.Address.PostalCode,
                City = user.Address.City
            };
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _context.Users.AnyAsync(x => x.Email == username);
        }

        public async Task<ActionResult> VerifyUserAsync(AuthenticateUser model)
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

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], 
                _configuration["Jwt:Audience"], 
                claims, 
                expires: DateTime.Now.AddDays(1), 
                signingCredentials: credentials);

            return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
