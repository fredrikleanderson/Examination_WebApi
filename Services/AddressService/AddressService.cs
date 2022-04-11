using Examination_WebApi.Data;
using Examination_WebApi.Models.Entities;
using Examination_WebApi.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Examination_WebApi.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly DataContext _context;

        public AddressService(DataContext context)
        {
            _context = context;
        }

        public async Task<AddressEntity> FindOrCreateAddressAsync(CreateUser model)
        {
            AddressEntity? address = await _context.Addresses
                .Where(x => x.StreetAddress == model.StreetAddress && x.PostalCode == model.PostalCode 
                && x.City == model.City).FirstOrDefaultAsync();

            if (address != null)
            {
                return address;
            }

            address = new AddressEntity
            {
                StreetAddress = model.StreetAddress,
                PostalCode = model.PostalCode,
                City = model.City
            };

            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            return address;
        }

        public async Task RemoveEmptyAddressesAsync(int id)
        {
            AddressEntity? address = await _context.Addresses.FindAsync(id);

            if (address == null)
            {
                return;
            }

            List<UserEntity>? users = await _context.Users.Include(x => x.Address)
                .Where(x => x.AddressId == id).ToListAsync();

            if (!users.Any() && address != null)
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
            }
        }
    }
}
