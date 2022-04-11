using Examination_WebApi.Models.Entities;
using Examination_WebApi.Models.Users;

namespace Examination_WebApi.Services.AddressService
{
    public interface IAddressService
    {
        Task<AddressEntity> FindOrCreateAddressAsync(CreateUser model);
        Task RemoveEmptyAddressesAsync(int id);
    }
}
